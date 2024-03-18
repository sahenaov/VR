using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit;

public class FlashLight : MonoBehaviour
{
    public InputActionProperty FirstButtonValue, SecondButtonValue;
    public Light flashLight;
    private float ValueFirstButton = 0, ValueSecondButton = 0;
    [SerializeField] private XRDirectInteractor Interactable;


    public void Update()
    {
        ValueFirstButton = FirstButtonValue.action.ReadValue<float>();

        if (ValueFirstButton>0.9)
        {
            flashLight.enabled = true;
        }

        ValueSecondButton = SecondButtonValue.action.ReadValue<float>();

        if (ValueSecondButton > 0.9)
        {
            flashLight.enabled = false;
        }

        
    }



}
