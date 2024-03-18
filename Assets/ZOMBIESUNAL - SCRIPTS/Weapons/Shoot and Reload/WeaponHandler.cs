using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class WeaponHandler : MonoBehaviour
{
    #region Variables
    
    [Header("Weapon info")]
    public WeaponInfo weaponInfo;
    [SerializeField] private LayerMask layerMask;

    [Header("Events")]
    public UnityEvent ShootEvent;
    public UnityEvent ReloadEvent;
    public UnityEvent SniperEvent;

    [Header("Text")]
    public TextMeshProUGUI textAmmo;
    public TextMeshProUGUI textMagazines;

    #region PrivateVa and Hidden

    private int currentAmmo = 0;
    private int currentMagazines;
    private int stepsMade;
    [HideInInspector] public bool canShoot;
    [HideInInspector] public bool sniperShoot = true;
    private new ParticleSystem particleSystem;
    private GameObject barrel;
    private bool isOnParticleS;

    #endregion

    #endregion

    #region Initialization

    private void OnDisable()
    {
        //Turn off particle system for do not get issues
        isOnParticleS = false; particleSystem.gameObject.SetActive(false);
    }

    void Start()
    {
        particleSystem = GetComponentInChildren<ParticleSystem>();
        barrel = particleSystem.gameObject.GetComponent<Transform>().parent.gameObject;
        particleSystem.gameObject.SetActive(false);
        currentMagazines = weaponInfo.magazines;
        textMagazines.text = currentMagazines.ToString(); 
    }

    #endregion

    public void StepDone()
    {
        //Realizó un paso de la recarga
        stepsMade++;
        Reload();
    }

    private void Reload()
    {
        if(stepsMade != weaponInfo.stepsReload) return;

        //Puede disparar
        AudioSource.PlayClipAtPoint(weaponInfo.onFirstSelect,transform.position);

        if(currentMagazines < weaponInfo.maxAmmo){textMagazines.text = "0"; }
        else {textMagazines.text = (currentMagazines - weaponInfo.maxAmmo).ToString(); }

        if(currentMagazines >= weaponInfo.maxAmmo){currentAmmo = weaponInfo.maxAmmo;}
        else{currentAmmo = currentMagazines;}
        
        textAmmo.text = currentAmmo.ToString(); 

        canShoot = true; 
    }

    [ContextMenu("Shoot")]
    public void Shoot()
    {
        if(stepsMade != weaponInfo.stepsReload) {return;}
        if(currentMagazines == 0) { AudioSource.PlayClipAtPoint(weaponInfo.onFirstSelect, transform.position); return;}
        if(currentAmmo <= 0) { MustReload(); AudioSource.PlayClipAtPoint(weaponInfo.onFirstSelect, transform.position); return;}
        if(!weaponInfo.onActive || !canShoot) {return;}
        if(!sniperShoot) {return;}

        //Active Audio and ParticleSystem
        AudioSource.PlayClipAtPoint(weaponInfo.onActive, transform.position);
        ShootEvent.Invoke();

        isOnParticleS = PlayParticleSystem(isOnParticleS);

        //Do the up force to the gun
        Rigidbody gun = this.gameObject.transform.GetComponent<Rigidbody>();
        gun.AddForce(-barrel.transform.forward * weaponInfo.recoil);

        //Look what it hitted (if hitted something)
        RaycastHit hit;
        if (Physics.Raycast(barrel.transform.position, barrel.transform.forward, out hit, weaponInfo.range, layerMask))
        {
            TargetShot target = hit.transform.GetComponent<TargetShot>();
            if (target != null)
            {
                target.GetShot(weaponInfo);
            }

            GameObject impactGO = Instantiate(weaponInfo.impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);

            GameObject bulletGO = Instantiate(weaponInfo.bulletImage, hit.point, hit.transform.rotation);
            Destroy(bulletGO, 10f);
        }

        //Update ammo
        currentAmmo --;
        currentMagazines --;
        textAmmo.text = currentAmmo.ToString();

        //If is a sniper, check if pull every time that shot
        if(weaponInfo.type == TypeGun.Sniper && currentAmmo > 0) 
        {
            //Debug.Log("sniperShoot reload");
            sniperShoot = false;
            SniperEvent.Invoke();
            return;
        }  

        if (currentAmmo <= 0) 
        { 
            //Update magazines

            if(currentMagazines == 0) { return;} //Do not have more magazines
            //Debug.Log("Must reload");
            MustReload(); 
        }
    }
    
    [ContextMenu("Must Reload")]
    public void MustReload()
    {
        if(canShoot == false || currentAmmo == weaponInfo.maxAmmo || currentMagazines == 0){return;}
        if(textMagazines.text == "0") {return;}

        //Reset all steps and Invoke
        if(weaponInfo.type == TypeGun.Sniper) { SniperShoot(); }  

        stepsMade = 0;
        canShoot = false;
        ReloadEvent.Invoke();
    }

    public void SniperShoot()
    {
        sniperShoot = true;
    }

    public bool PlayParticleSystem(bool isOn)
    {
        //Particle System Handler
        if (isOn)
        {
            //If it's on just play particle system
            particleSystem.Play();
        }
        else
        {
            //If it's not turn on the gameObject
            particleSystem.gameObject.SetActive(true);
        }
        return true;
    }
}
