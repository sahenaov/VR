using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TwoHandsGrab : XRGrabInteractable
{
    public List<XRSimpleInteractable> secondHandGrabPoints = new List<XRSimpleInteractable>();
    private IXRSelectInteractor firstInteractor,secondInteractor;
    Transform initial;
    Vector3 pos;
    Quaternion rot;
    private void Start()
    {
        initial = GetComponent<Transform>();
        pos = initial.transform.localPosition;
        rot = initial.localRotation;
        foreach (var item in secondHandGrabPoints)
       {
            item.selectEntered.AddListener(OnSecondHandGrab);
            item.selectExited.AddListener(OnSecondHandRelease);
       }
    }
    
    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {
        // compute rotation
        if (firstInteractor != null && secondInteractor != null)
        {
            firstInteractor.transform.rotation = Quaternion.LookRotation(secondInteractor.transform.position - firstInteractor.transform.position,firstInteractor.transform.up);
            
        }
        base.ProcessInteractable(updatePhase);
    }
    //----------first interactor------------
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        firstInteractor = args.interactorObject;
        
        base.OnSelectEntered(args);
    }
    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        
        firstInteractor = null;
        secondInteractor = null;
        base.OnSelectExited(args);
    }
    //------------second intercator------------------
    public void OnSecondHandGrab(SelectEnterEventArgs args)=> secondInteractor = args.interactorObject;
    public void OnSecondHandRelease(SelectExitEventArgs args) { 
        secondInteractor = null;
        // return to a initial position
        transform.localPosition = pos;
        transform.localRotation = rot;
    }

}
