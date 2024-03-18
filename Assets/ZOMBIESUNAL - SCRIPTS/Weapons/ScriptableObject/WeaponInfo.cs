using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapons")]
public class WeaponInfo : ScriptableObject
{
    [Header("Type")]
    public string nameGun;
    public TypeGun type;
    [HideInInspector] public bool stepsShoot;

    [Header("Munition")]
    public int stepsReload;
    public int maxAmmo;
    public int magazines;

    [Header("Statistics")]
    public float damage_Head;
    public float damage_Body;
    public float damage_Feet;

    public float dispertion;
    public float mobility;
    public float recoil;
    public float cadence;
    public float range;
    public PenetracionPared penetracionPared;
    public float velocidadDisparoMira;
    public float velocidadDisparoNormal;
    public float zoom;
    public float velocidadRecarga;

    [Header("Sounds")]
    public AudioClip onFirstEnter;
    public AudioClip onLastEnter;
    public AudioClip onHoverEnter;
    public AudioClip onHoverExit;
    public AudioClip onFirstSelect;
    public AudioClip onLastSelect;
    public AudioClip onSelectEntered;
    public AudioClip onSelectExited;
    public AudioClip onActive;
    public AudioClip onDiactive;

    [Header("Other stuff")]
    public Sprite WeaponImage;
    public GameObject impactEffect;
    public GameObject bulletImage;
}
public enum TypeGun
{
    AR,SMG,Pistol,Sniper,Shotgun,Riffle,Semirifles,Revolvers
}

public enum PenetracionPared
{
    Alta, Media_Alta, Media, Media_Baja, Baja
}
