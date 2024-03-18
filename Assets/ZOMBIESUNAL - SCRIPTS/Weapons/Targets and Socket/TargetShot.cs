using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetShot : MonoBehaviour
{
    public enum BodyPart{head, body, legs}
    [SerializeField] private BodyPart bodyPart;

    private TargetHandler targetHandler;

    private void Start()
    {
        targetHandler = GetComponentInParent<TargetHandler>();
    }

    public void GetShot(WeaponInfo weaponInfo)
    {
        if(bodyPart == BodyPart.head)
        {
            //Hit head
            targetHandler.GetDamage(weaponInfo.damage_Head);    
            return;
        }

        else if(bodyPart == BodyPart.body)
        {
            //Hit body
            targetHandler.GetDamage(weaponInfo.damage_Body);
            return;
        }

        else
        {
            //Hit legs
            targetHandler.GetDamage(weaponInfo.damage_Feet);
        }
    }
}
