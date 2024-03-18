using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Inputs;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.XR;
using UnityEngine.InputSystem;

public class MagazineReloading : MonoBehaviour
{
    #region Variables

    [SerializeField] private float timeForRecover = 0.1f;
    [SerializeField] private XRSocketInteractorTag MagazineLocation;
    [SerializeField] private Transform startTransform, locationTransform;

    #region Private and Hidden

    private Quaternion saveRotationHand;

    private MeshRenderer meshRenderer;
    private Transform parent;
    private WeaponHandler weaponHandler;
    private XROffsetGrabInteractable xRGrabInteractable;
    private bool inSocket;

    #endregion

    #endregion

    private void Start()
    {
        xRGrabInteractable = GetComponent<XROffsetGrabInteractable>();
        weaponHandler = GetComponentInParent<WeaponHandler>();

        xRGrabInteractable.selectEntered.AddListener(OnGrab);
        xRGrabInteractable.selectExited.AddListener(OnRelease);

        parent = this.transform.parent;
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        //Debug.Log("Grab");
    }

    private void OnRelease(SelectExitEventArgs args)
    {
        //Debug.Log("Release");
        StartCoroutine("DisableRelease");
    }

    IEnumerator DisableRelease()
    {
        yield return new WaitForSeconds(0.02f);
        if(!inSocket)
        {
            this.gameObject.GetComponent<Transform>().position = startTransform.position;
        }
    }

    public void OnMaganizeEntered()
    {
        StartCoroutine("MagazineDisableGrab");

        inSocket = true;
        this.transform.SetParent(parent);
        weaponHandler.StepDone();
    }

    IEnumerator MagazineDisableGrab()
    {
        yield return new WaitForSeconds(0.01f);
        xRGrabInteractable.enabled = false;
        this.gameObject.GetComponent<Transform>().position = locationTransform.position;
    }

    public void Reload()
    {
        inSocket = false;
        MagazineLocation.gameObject.SetActive(false);
        xRGrabInteractable.enabled = true;

        this.gameObject.GetComponent<Transform>().position = startTransform.position;
        StartCoroutine("MagazineSocketDisable");
    }

    IEnumerator MagazineSocketDisable()
    {
        yield return new WaitForSeconds(timeForRecover);

        MagazineLocation.gameObject.SetActive(true);
    }
}
