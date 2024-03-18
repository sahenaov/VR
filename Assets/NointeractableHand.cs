using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class NointeractableHand : MonoBehaviour
{
    public GameObject FlashLight;
    private XRRayInteractor Interactor;
    void Start()
    {
        Interactor = GetComponent<XRRayInteractor>();
    }
    private void Update()
    {
        if (FlashLight.activeSelf == true){
            Interactor.enabled = false;
        }
        else
        {
            Interactor.enabled = true;
        }
    }
}
