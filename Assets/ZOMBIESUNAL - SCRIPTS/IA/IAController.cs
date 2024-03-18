using UnityEngine;
using UnityEngine.AI;

public class IAController : MonoBehaviour
{
    [Header("IA Values")]
    [SerializeField] private IA_FieldOfView iA_FieldOfView;
    public float lookRadius;
    [Range(0, 360)]
    public float angle;
    public float speed;
    public float stoppingDistance;

    [Header("Animator")]
    [SerializeField] private Animator animatorZombie;
    [SerializeField] private string movementName = "Movement", attackName = "Attack";

    [Header("Interpolation values")]
    [SerializeField] private float idleAnimationValue = 0.0f;
    [SerializeField] private float walkingAnimationValue = 0.5f;
    [SerializeField] private float movementAnimationValue = 1.0f;
    [SerializeField] private float runningAnimationValue = 2.0f;
    [SerializeField] private float interpolationTime = 3.2f;

    [HideInInspector] public Transform target; 
    NavMeshAgent agent;
    private bool isWalking = false, isAttacking;
    static float t = 0.0f;
    private float lerpValue, distance, initialAngle, initialSpeed, initialLookRadius, initialIdle = 0.0f;
    private Vector3 startingPosition;
    private Vector3 roamPosition;

    [Header("State")]
    public States initialState;

    [Header("Walking values")]
    [SerializeField] private Vector2 distanceMovement = new Vector2(1.0f, 1.25f);
    [SerializeField] private float velocityOfMovement = 1.0f;

    private States currentState = States.idle;

    public enum States
    {
        idle, walking, chasing, running, attacking
    }
    void Start()
    {
        //Update IA values
        initialAngle = angle;
        initialSpeed = speed;
        initialLookRadius = lookRadius;
        currentState = initialState;
        startingPosition = this.transform.position;
        roamPosition = GetRoamPosition();
        initialIdle = idleAnimationValue;
        if(currentState == States.walking)
            initialIdle = walkingAnimationValue;
                                    
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();

        animatorZombie.SetFloat(movementName, initialIdle);

        agent.speed = this.speed;
        agent.stoppingDistance = this.stoppingDistance;
    }

    #region States

    void CurrentState()
    {
        switch(currentState)
        {
            case States.idle:
                IdleState();
                break;

            case States.walking:
                WalkingState();
                break;

            case States.chasing:
                ChasingState();
                break;

            case States.running:
                RunningState();
                break;

            case States.attacking:
                AttackingState();
                break;
        }
    }

    void IdleState()
    {
        //Update IA values
        angle = initialAngle;
        agent.speed = this.speed;
        iA_FieldOfView.SetFieldValues();

        //If see the target, start chasing
        if(iA_FieldOfView.canSeePlayer)
            currentState = States.chasing; 
        else    
            StopNavMesh();
    }

    void WalkingState()
    {
        //Update animator to be quiet
        if(isWalking && UpdateAnimator(movementAnimationValue, initialIdle, movementName))
        { 
            isWalking = false; 
            animatorZombie.SetFloat(movementName, initialIdle);  
        }

        //Update IA values
        angle = initialAngle;
        agent.speed = this.velocityOfMovement;
        iA_FieldOfView.SetFieldValues();

        if(iA_FieldOfView.canSeePlayer) {currentState = States.chasing; return;}
            
        //JUST WALK AROUND A LITTLE AREA
        agent.SetDestination(roamPosition);
        if(Vector3.Distance(transform.position, roamPosition) < 1f || agent.velocity.magnitude == 0)
        {
            //Reached roam position
            roamPosition = GetRoamPosition();
        }
    }

    void ChasingState()
    {
        //Update IA values
        angle = 360;
        iA_FieldOfView.SetFieldValues();
        agent.speed = this.speed;
        agent.stoppingDistance = this.stoppingDistance;

        //Just return the zombies state to the initial one if stops to see the player
        if(!iA_FieldOfView.canSeePlayer)
            currentState = initialState; 
        else 
            UpdateNavMesh();
    }

    void RunningState()
    {
        //TO DO: Just run when is lighet by the lantern
    }

    void AttackingState()
    {
        //Update IA values
        agent.stoppingDistance = this.stoppingDistance + 0.5f;

        //Attack the target

        //Face the target
        FaceTarget();

        //Went out to the attacking area it means it is ready to walk
        if(distance <= agent.stoppingDistance) return;

        currentState = States.chasing;
        isWalking = true; 
        animatorZombie.SetBool(attackName, false);
    }

    #endregion

    #region Update
    private void Update()
    {
        distance = Vector3.Distance(target.position, transform.position);
        CurrentState();
    }

    public void UpdateNavMesh()
    {
        agent.isStopped = false;
        agent.SetDestination(target.position);

        //Update chase mode
        if(!isWalking && UpdateAnimator(initialIdle, movementAnimationValue, movementName))
        { 
            isWalking = true;
            return;
        }

        if(distance > agent.stoppingDistance) return;
        
        //Update attacking mode
        if(isWalking)
        { 
            currentState = States.attacking;

            isWalking = false;
            animatorZombie.SetBool(attackName, true);
        }
    }

    public void StopNavMesh()
    {
        if(agent.isStopped && !isWalking && !isAttacking) return;

        agent.isStopped = true;
        //Update animator to be quiet
        if(isWalking && UpdateAnimator(movementAnimationValue, initialIdle, movementName))
        { 
            isWalking = false; 
            animatorZombie.SetFloat(movementName, initialIdle);  
        }
    }
    #endregion

    #region Animator Lerp
    bool UpdateAnimator(float init, float finish, string animatorVar)
    {
        //Make a lerp between the values for the animation
        lerpValue = Mathf.Lerp(init, finish, t);
        t += interpolationTime * Time.deltaTime;
        animatorZombie.SetFloat(animatorVar, lerpValue);

        if(finish>init)
        {   
            if(lerpValue>=finish)
            {
                animatorZombie.SetFloat(animatorVar, finish);
                lerpValue = 0;
                t = 0.0f;
                return true;
            }
        }
        else
        {
            if(lerpValue<=finish)
            {
                animatorZombie.SetFloat(animatorVar, finish);
                lerpValue = 0;
                t = 0.0f;
                return true;
            }
        }
        return false;
    }
    #endregion

    void FaceTarget()
    {
        //Just look to the target constantly
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 7.5f);
    }

    Vector3 GetRoamPosition()
    {
        float ran = Random.Range(distanceMovement.x, distanceMovement.y);
        return (startingPosition 
            + new Vector3(UnityEngine.Random.Range(-1f, 1f), 0, UnityEngine.Random.Range(-1f, 1f)).normalized)
            * ran;
    }
}
