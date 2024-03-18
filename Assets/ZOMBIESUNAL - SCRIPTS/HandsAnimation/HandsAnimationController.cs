using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandsAnimationController : MonoBehaviour
{
    public InputActionProperty pinchAnimationAction, gripAnimationAction;

    [SerializeField] private Animator handAnimator;
    float triggerValue, gripValue;

    private void Update()
    {
        //Trigger
        triggerValue = pinchAnimationAction.action.ReadValue<float>();
        handAnimator.SetFloat("Trigger", triggerValue);

        //Grip 
        gripValue = gripAnimationAction.action.ReadValue<float>();
        handAnimator.SetFloat("Grip", gripValue);


    }
    
}
