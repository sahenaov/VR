using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;


public class SaveWeapons : MonoBehaviour
{
    #region Variables
    public UnityEvent OnActiveWeapon, OnDiactiveWeapon;

    [SerializeField] private GameObject Weapon;
    [SerializeField] private Animator screenAnimator;

    #region Private and Hidden

    [SerializeField] private InputHands inputHands;
    private bool _isOn = true, screenBool;

    #endregion

    #endregion

    #region Initialization

    private void Start()
    {
        inputHands.weaponHand.buttons.ButtonAX.started += OnSaveWeapon;
    }

    #endregion

    #region Functions

    public void OnSaveWeapon(InputAction.CallbackContext context)
    {
        SaveEditor();
    }

    [ContextMenu("Save Weapon")]
    public void SaveEditor()
    {
        if(!_isOn)
        {
            _isOn = true;
            Weapon.SetActive(true); 
            OnActiveWeapon.Invoke();

            if(screenBool) 
            {
                screenAnimator.SetTrigger("MotionScreen");
            }

            return;
        }
        else
        {
            _isOn = false;
            Weapon.SetActive(false); 
            OnDiactiveWeapon.Invoke();
        }
    }

    public void ScreenBool(bool on)
    {
        screenBool = on;
        if(screenBool) {return;}

        screenAnimator.SetTrigger("MotionScreenOFF");
    }

    #endregion
}
