using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[Serializable]
public class GrabManager : MonoBehaviour
{
    [SerializeField]
     bool isPrimaryRight=false;
    [SerializeField]
    private InteractionLayerMask primaryGrab, secondGrab;

    [SerializeField]
    private XRDirectInteractor leftHand, rightHand;
    
    public Transform leftParent, rightParent;
    
    private Transform parentgrab;

    private void Awake()
    {
        SetGrabOrientation();
    }
    private void SetGrabOrientation()
    {
        if (isPrimaryRight)
        {
            rightHand.interactionLayers= primaryGrab;
            leftHand.interactionLayers= secondGrab;

            parentgrab = rightParent;
        }
        else
        {
            leftHand.interactionLayers = primaryGrab;
            rightHand.interactionLayers = secondGrab;

            parentgrab = leftParent;
        }
    }
    public bool IsPrimaryRight
    {
        set
        {
            isPrimaryRight = value;

        }
        get => isPrimaryRight;
    }
    public Transform ParentGrab { get=> parentgrab; }

}
