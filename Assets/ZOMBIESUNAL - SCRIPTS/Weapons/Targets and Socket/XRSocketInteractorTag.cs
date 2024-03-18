using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRSocketInteractorTag : XRSocketInteractor
{
    [SerializeField] private OnTargetReached onTargetReached;

    public string targetTag;

    [System.Obsolete]
    public override bool CanSelect(XRBaseInteractable interactable)
    {
        if(onTargetReached != null) {onTargetReached.firstTime = true; onTargetReached.t = 0.0f;}
        return base.CanSelect(interactable) && interactable.CompareTag(targetTag);
    }
}
