using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class OnTargetReached : MonoBehaviour
{
    #region Variables

    [Header("Bullets")]
    [SerializeField] private BulletHandler bulletHandler;

    [Header("targetFrom transform and distans treshold")]
    public Transform targetFrom, targetTo;
    public float treshold = 0.02f;
    private bool wasReached, allow;
    private Transform handTransform;

    [Header("Animator")]
    [SerializeField] private PositionHandler positionHandler;
    [Range(1,100)]
    [SerializeField] private float velocity;
    [SerializeField] private float offsetDistance = 5.4f;

    [Header("Main Hand")]
    public MainHand mainHand;

    [Header("Event after reach")]
    public UnityEvent OnReached;

    #region Private Variables and Hidden

    [SerializeField] private InputHands inputHands;
    private XROffsetGrabInteractable xROffsetGrabInteractable;
    private WeaponHandler weaponHandler;
    private float lerp;
    private bool canPull;
    private BoxCollider boxCollider;

    [HideInInspector] public float t;
    [HideInInspector] public bool firstTime, test; 

    #endregion

    #endregion

    #region Initialization and Decomissing

    private void Start()
    {
        inputHands.weaponHand.buttons.Grip.started += GripActionDown;
        inputHands.weaponHand.buttons.Grip.canceled += GripActionUp;
        
        xROffsetGrabInteractable = GetComponent<XROffsetGrabInteractable>();
        weaponHandler = GetComponentInParent<WeaponHandler>();
        boxCollider = GetComponent<BoxCollider>();
        Restore(false);
    }

    public void Restore(bool can)
    {
        if(can)
        {
            //Enable all variables
            xROffsetGrabInteractable.enabled = true;
            canPull = false;

            positionHandler.enabled = false;
            
            boxCollider.enabled = true;
            
            xROffsetGrabInteractable.selectEntered.AddListener(ActiveAnim);
        }
        else
        {
            //Disabling all variables

            positionHandler.enabled = false;
            
            boxCollider.enabled = false;
        }
    }

    #endregion 

    #region Triggers

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("LeftHand")) {return;}
        xROffsetGrabInteractable.enabled = true;
        canPull = true;
    }

    void OnTriggerExit(Collider other)
    {
        if(xROffsetGrabInteractable.enabled == false) {return;}
        canPull = false;
    }

    #endregion

    #region TriggerActionControl

    [ContextMenu("Active Anim")]
    public void ActiveAnimTest()
    {
        //This is only for testing without VR glasses
        t = 0.0f;
        allow = true;
        xROffsetGrabInteractable.enabled = false;

        if(mainHand == MainHand.Right)
        {
            handTransform = GameObject.FindGameObjectWithTag("LeftHand").transform;
        }
        else
        {
            handTransform = GameObject.FindGameObjectWithTag("RightHand").transform;
        }
    }

    private void ActiveAnim(SelectEnterEventArgs args)
    {
        t = 0.0f;
        allow = true;
        xROffsetGrabInteractable.enabled = false;

        if(mainHand == MainHand.Right)
        {
            handTransform = GameObject.FindGameObjectWithTag("LeftHand").transform;
        }
        else
        {
            handTransform = GameObject.FindGameObjectWithTag("RightHand").transform;
        }
    }

    public void GripActionDown(InputAction.CallbackContext context)
    {
        if(!canPull) {return;}
        allow = true;
    }

    public void GripActionUp(InputAction.CallbackContext context)
    {
        if(wasReached) {return;}
        allow = false;
        canPull = false;
        xROffsetGrabInteractable.enabled = false;
    }

    #endregion

    #region Update

    private void Update()
    {
        if(!firstTime) {return;}
        allow = false;
        LerpPosition(1);

        if(t > 1) {firstTime = false;}
    }

    private void FixedUpdate()
    {
        if(firstTime) {return;}
        if(handTransform is null) {return;}
        
        float distance_this = Vector3.Distance(this.transform.position, targetFrom.position);
        float distance = Vector3.Distance(handTransform.position, targetTo.position);
        
        //Debug.Log("Animation: " + -distance*10 + offsetDistance);
        if(allow) //Gets the distance until it reaches the position of the targetFrom
        {
            if(!wasReached && !test)
            {
                //Animación de inicio
                positionHandler.PositionByAnimation("Lock", "Pull", (-distance*10 + offsetDistance));
                
            }
            else if(wasReached)
            {
                //Animación de final
                LerpPosition(1);
            }

            if(distance_this < treshold  && !wasReached)
            {
                //Calcula distancia sin haber cargado
                OnReached.Invoke();
                wasReached = true;
                if (!weaponHandler.sniperShoot) {AudioSource.PlayClipAtPoint(weaponHandler.weaponInfo.onFirstSelect, transform.position);} 
                
            }

            else if(t > 1 && wasReached) //Diactive everything
            {
                //Termina todo el proceso
                wasReached = false;
                allow = false;

                positionHandler.PositionByAnimation("Lock", "Pull", 0.0f);
                

                xROffsetGrabInteractable.enabled = false;

                Restore(false);

                if (weaponHandler.sniperShoot) {weaponHandler.StepDone();}
                else{weaponHandler.SniperShoot();}
            }
            return;
        }
        else if(t <= 1)
        {
            LerpPosition(-distance*10 + offsetDistance);
        }
    }
    
    private void LerpPosition(float currentP)
    {
        //Lerping
        lerp = Mathf.Lerp(currentP, 0, t);
        positionHandler.PositionByAnimation("Lock", "Pull", lerp);

        t += 0.5f * Time.deltaTime * velocity;

        if(t > 1)
        {
            positionHandler.PositionByAnimation("Lock", "Pull", 0.0f);
        }
    }

    #endregion

    #region Bullets

    public void BulletShot()
    {
        bulletHandler.BulletShot();
    }

    #endregion
}

public enum MainHand{Right, Left}
