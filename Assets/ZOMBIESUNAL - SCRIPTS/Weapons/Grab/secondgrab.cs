using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class secondgrab : MonoBehaviour
{
 
    public List<XRSimpleInteractable> secondHandGrabPoints = new List<XRSimpleInteractable>();
    private IXRSelectInteractor secondInteractor;
     
    GrabManager managerGrab=null;
    Transform handparent;
    Transform initial;
    public OffsetAttachWeapon leftoffset,rightoffest;
    
    private void Start()
    {
        // searching GrabManager
        managerGrab= FindObjectOfType<GrabManager>();
        if (managerGrab == null)
        {
            Debug.LogError("no manager grab");
            Destroy(this);
            return;
        }

        handparent = managerGrab.ParentGrab;
        transform.SetParent( handparent);
        // inital transform position and rotation object

        initransform();

        foreach (var item in secondHandGrabPoints)
        {
            item.selectEntered.AddListener(OnSecondHandGrab);
            item.selectExited.AddListener(OnSecondHandRelease);
        }
    }

    private void Update()
    {
        if (secondInteractor == null) return;
        transform.rotation = Quaternion.LookRotation(secondInteractor.transform.position- handparent.position,handparent.forward);
    }

    public void OnSecondHandGrab(SelectEnterEventArgs args)=> secondInteractor = args.interactorObject;
       
    
    public void OnSecondHandRelease(SelectExitEventArgs args)
    {
        secondInteractor = null;
        // return to a initial position
        initransform();
        
    }
    public void initransform()
    {
        if (managerGrab.IsPrimaryRight)
        {
            transform.localPosition = rightoffest.offsetPosition;
            transform.localRotation = Quaternion.Euler(rightoffest.offsetRotation.x, rightoffest.offsetRotation.y, rightoffest.offsetRotation.z);
        }
        else
        {
            transform.localPosition = leftoffset.offsetPosition;
            transform.localRotation = Quaternion.Euler(leftoffset.offsetRotation.x, leftoffset.offsetRotation.y, leftoffset.offsetRotation.z);
        }
    }
}
