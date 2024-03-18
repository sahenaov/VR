using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class InputHands : MonoBehaviour
{
    public XRIDefaultInputActions interaction;
    public bool isWeaponRight = true;
    [HideInInspector]
    //public InputAction weaponTrigger, weaponGrip, weaponEmpty;/// actions for weapon hand
    public InputHand powerHand;
    public InputHand weaponHand;

    private void Awake()
    {
        interaction = new XRIDefaultInputActions();
        SelectHand();
    }
   
    private void OnEnable()
    {
        interaction.Enable();
    }
    private void OnDisable()
    {
        interaction.Disable();
    }
    private void SelectHand()
    {
        if (isWeaponRight)
        {
            weaponHand.buttons.Grip = interaction.XRIRightHandInteraction.Select;
            weaponHand.buttons.Trigger= interaction.XRIRightHandInteraction.Activate;           
            weaponHand.buttons.ButtonAX= interaction.XRIRightHandInteraction.PrimaryButton;
            weaponHand.buttons.ButtonBY= interaction.XRIRightHandInteraction.SecondButton;
            weaponHand.buttons.Stickbutton= interaction.XRIRightHandInteraction.Thumbstick;
            weaponHand.analog.Trigger = interaction.XRIRightHandInteraction.ActivateValue;
            weaponHand.analog.Grip = interaction.XRIRightHandInteraction.SelectValue;
            weaponHand.analog.Move= interaction.XRIRightHandLocomotion.Move;
            weaponHand.analog.Turn= interaction.XRIRightHandLocomotion.Turn;
            ////
           powerHand.buttons.Grip = interaction.XRILeftHandInteraction.Select;
           powerHand.buttons.Trigger = interaction.XRILeftHandInteraction.Activate;
           powerHand.buttons.ButtonAX = interaction.XRILeftHandInteraction.PrimaryButton;
           powerHand.buttons.ButtonBY = interaction.XRILeftHandInteraction.SecondaryButton;
           powerHand.analog.Trigger = interaction.XRILeftHandInteraction.ActivateValue;
           powerHand.analog.Grip = interaction.XRILeftHandInteraction.SelectValue;
           powerHand.analog.Move = interaction.XRILeftHandLocomotion.Move;
           powerHand.analog.Turn = interaction.XRILeftHandLocomotion.Turn;
          
        }
        else
        {
           
            powerHand.buttons.Grip = interaction.XRIRightHandInteraction.Select;
            powerHand.buttons.Trigger = interaction.XRIRightHandInteraction.Activate;
            powerHand.buttons.ButtonAX = interaction.XRIRightHandInteraction.PrimaryButton;
            powerHand.buttons.ButtonBY = interaction.XRIRightHandInteraction.SecondButton;
            powerHand.buttons.Stickbutton = interaction.XRIRightHandInteraction.Thumbstick;
            powerHand.analog.Trigger = interaction.XRIRightHandInteraction.ActivateValue;
            powerHand.analog.Grip = interaction.XRIRightHandInteraction.SelectValue;
            powerHand.analog.Move = interaction.XRIRightHandLocomotion.Move;
            powerHand.analog.Turn= interaction.XRIRightHandLocomotion.Turn;

            weaponHand.buttons.Grip = interaction.XRILeftHandInteraction.Select;
            weaponHand.buttons.Trigger = interaction.XRILeftHandInteraction.Activate;
            weaponHand.buttons.ButtonAX = interaction.XRILeftHandInteraction.PrimaryButton;
            weaponHand.buttons.ButtonBY = interaction.XRILeftHandInteraction.SecondaryButton;
            weaponHand.analog.Trigger = interaction.XRILeftHandInteraction.ActivateValue;
            weaponHand.analog.Grip = interaction.XRILeftHandInteraction.SelectValue;
            weaponHand.analog.Move = interaction.XRILeftHandLocomotion.Move;
            weaponHand.analog.Turn = interaction.XRILeftHandLocomotion.Turn;


        }

    }


    [ContextMenu("set weapon")]
    public void SetisWeaponRight()
    {
        SelectHand();
    }
}


// hand binding base--------------
public struct InputHand
{
    public ControlButtons buttons;
    public ControlAnalogs analog;
}



public struct ControlButtons
{
    public InputAction Trigger, Grip, ButtonAX, ButtonBY, Stickbutton;
}

public struct ControlAnalogs
{
    public InputAction Trigger, Grip, Move,Turn;
}
