using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpInteractable : MonoBehaviour
{
    #region Variables

    [SerializeField, ColorUsage(showAlpha: true, hdr: true)] 
    private Color colorToLerp;
    
    [SerializeField, ColorUsage(showAlpha: true, hdr: true)] 
    private Color OriginalColor;

    [Range(1,5)]
    [SerializeField] private float Velocity;
    //[SerializeField] private 

    #region Private and Hidden

    private MeshRenderer meshRenderer;
    private bool canLerp;

    #endregion

    #endregion

    #region Initialization

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material.EnableKeyword("_EMISSION"); 
    }

    private void OnEnable()
    {
        canLerp = true;
    }

    #endregion

    #region Decommissioning

    private void OnDisable()
    {
        meshRenderer.material.SetVector("_EmissionColor", (Vector4)OriginalColor);
    }

    #endregion

    #region Trigger

    /*private void OnTriggerEnter(Collider other)
    {
        canLerp = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if(this.enabled == false) {return;}
        canLerp = false;
        meshRenderer.material.color = LerpingColor.color;
    }*/

    #endregion

    #region Update

    private void Update()
    {
        if(!canLerp) {return;}

        meshRenderer.material.SetVector("_EmissionColor", (Vector4)Color.Lerp(OriginalColor , colorToLerp, Mathf.PingPong(Time.time*Velocity, 1)));
        //meshRenderer = Color.Lerp(LerpingColor.color, colorToLerp, Mathf.PingPong(Time.time*Velocity, 1));
    }

    #endregion
}
