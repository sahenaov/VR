using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;


public class weaponfire : MonoBehaviour
{
    public UnityEvent ongrabgun,fire, reload;
    [SerializeField] private InputHands inputHands;

    private void Start()
    {
        inputHands.weaponHand.buttons.Trigger.started += OnFire;
        inputHands.weaponHand.buttons.Stickbutton.started += OnReload;

        ongrabgun.Invoke();
    }

    public void OnFire(InputAction.CallbackContext context)
    {
        fire.Invoke();
    }

    public void OnReload(InputAction.CallbackContext context)
    {
        reload.Invoke();
    }
}
