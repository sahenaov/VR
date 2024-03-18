using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;

public class PlayerFeatures : MonoBehaviour
{
    [Header("Features for the Player")]
    public float life = 100.0f;

    [Header("Scene Features")]
    [SerializeField] private Color damageColor;
    [SerializeField] private Volume volume;

    Vignette vignette;
    Color mainColor;

    float t,delta=1;
    bool died;
    private void Start()
    {

        if(volume.profile.TryGet<Vignette>(out vignette))
            mainColor = vignette.color.value;
    }

    bool isLerping;
    private void Update()
    {
        if(!isLerping)
            return;
        
        t = Mathf.PingPong(Time.time, delta);
        vignette.color.value = Color.Lerp(mainColor, damageColor, t);

        if(t<0.1)
        {
            t = 0;
            isLerping = false;
        }
    }

    [ContextMenu("Take damage")]
    void TakeDamage()
    {
        isLerping = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if(died) return;    
        if(!other.CompareTag("Respawn")) return;

        life -= other.GetComponentInParent<IA_Features>().damage;
        TakeDamage();

        if(life<=0 && !died) Die();

    }

    void Die()
    {
        //DIE IN VR
        died = true;
        Debug.Log("DIE");
    }
}
