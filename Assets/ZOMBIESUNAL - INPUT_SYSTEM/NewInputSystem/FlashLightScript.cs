using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class FlashLightScript : MonoBehaviour
{
    Control FlashlightState;
    bool On, En;
    public Light flashLight, flashLightEn2;
    public GameObject FlashLightEn, flashLight2;
    [SerializeField] private XRDirectInteractor Interactable;


    private void OnEnable()
    {
        FlashlightState.Enable();
    }

    private void OnDisable()
    {
        FlashlightState.Disable();
    }
    private void Awake()
    {
        FlashlightState = new Control();
    }
    void Start()
    {
        FlashlightState.Flashlight.FirstButton.started+=FlashLightOn;
        FlashlightState.Flashlight.FirstButtonL.started += FlashLightOn2;
        FlashlightState.Flashlight.FirstButton.performed+= FlashLightPress;
        FlashlightState.Flashlight.FirstButton.canceled+= FlashLightOf;

        FlashlightState.Flashlight.SecondButton.started += FlashLightActive;
        FlashlightState.Flashlight.SecondButtonL.started += FlashLightActive2;
        FlashlightState.Flashlight.SecondButton.performed += FlashLightPress1;
        FlashlightState.Flashlight.SecondButton.canceled += FlashLightDeactivate;
    }
    void FlashLightActive(InputAction.CallbackContext Context)
    {
        FlashLightEn.SetActive(!FlashLightEn.activeSelf);
        flashLight2.SetActive(false);
        Interactable.enabled = !FlashLightEn.activeSelf;
    }
    void FlashLightActive2(InputAction.CallbackContext Context)
    {
        flashLight2.SetActive(!flashLight2.activeSelf);
        FlashLightEn.SetActive(false);
        Interactable.enabled = !FlashLightEn.activeSelf;
    }
    void FlashLightPress1(InputAction.CallbackContext Context)
    {

    }
    void FlashLightDeactivate(InputAction.CallbackContext Context)
    {

    }
    void FlashLightOn(InputAction.CallbackContext Context)
    {
        
        flashLight.enabled = !flashLight.enabled;

    }
    void FlashLightOn2(InputAction.CallbackContext Context)
    {

        flashLightEn2.enabled = !flashLightEn2.enabled;

    }
    
    void FlashLightPress(InputAction.CallbackContext Context)
    {
        
        
    }
    void FlashLightOf(InputAction.CallbackContext Context)
    {
        
    }
}

