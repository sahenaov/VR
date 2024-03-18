using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PlayerMovement : ActionBasedContinuousMoveProvider
{
    public static ActionBasedContinuousMoveProvider a;
    private void Start()
    {
        a = this;
    }
}
