using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class StepsSounds : MonoBehaviour
{
    public InputActionProperty leftJoystick, LeftSelectUi;

    float LeftJoystickValueX, LeftJoystickValueY, leftSelectValue, SpeedVel;
    Vector2 leftJoystickValue;

    public AudioSource source;
    private bool Flag = true;
    private void Start()
    {
    }
    private void Update()
    {
        //Left Joystick
        leftSelectValue = LeftSelectUi.action.ReadValue<float>();
        leftJoystickValue = leftJoystick.action.ReadValue<Vector2>();
        LeftJoystickValueX = leftJoystickValue.x;
        LeftJoystickValueY = leftJoystickValue.y;

        if (leftSelectValue > 0.7)
        {
            source.volume = 0.25f;
            PlayerMovement.a.moveSpeed = 0.35f;

        }
        else
        {
            source.volume = 1f;
            PlayerMovement.a.moveSpeed = 5f;
        }
        if ((LeftJoystickValueX < 0.1 && LeftJoystickValueX > -0.1) && (LeftJoystickValueY < 0.1 && LeftJoystickValueY > -0.1))
        {
            source.Stop();
            //Debug.Log("Stop");
            Flag = true;
        }
        else
        {
            if (Flag == true)
            {
                //source.PlayOneShot(clip);
                source.Play();
                //Debug.Log("Play");
                Flag = false;
            }
            else if (!source.isPlaying)
            {
                source.Play();
            }

        }
        //Debug.Log("Audio source is playing?: " + source.isPlaying);
    }

}
