using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

//IN A FIRST VIEW THE SCRIPTS 'IA_FIELDOFVIEW' AND 'IACONTROLLER' MUST WORK BY THEMSELVES, AFTER I HAVE TO JOIN THEM
public class IA_FieldOfView : MonoBehaviour
{
    [HideInInspector] public float radius;

    [Range(0, 360)]
    [HideInInspector] public float angle;

    [HideInInspector] public GameObject playerReference;

    public LayerMask targetMask;
    public LayerMask obstructionMask;

    [SerializeField] private IAController iAController;

    [HideInInspector] public bool canSeePlayer = false;

    void Start()
    {
        if(playerReference == null)
        {
            playerReference = PlayerManager.instance.player.gameObject;
        }
        
        SetFieldValues();
        StartCoroutine(FOVRoutine());
    }

    private IEnumerator FOVRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);
        
        while(true)
        {
            yield return wait;
            FieldOfViewCheck();
        }
    }

    private void FieldOfViewCheck()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);

        if(rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if(Vector3.Angle(transform.forward, directionToTarget) < angle/2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);
                if(!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                    canSeePlayer = true;
                    
                else
                {
                    canSeePlayer = false;
                }
            }
            else
                canSeePlayer = false;
        }
        else if(canSeePlayer)
            canSeePlayer = false;
    }

    public void SetFieldValues()
    {
        this.radius = iAController.lookRadius;
        this.angle = iAController.angle;
    }
}