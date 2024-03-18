using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA_Features : MonoBehaviour
{
    [Header("Features IA")]
    public float life = 100.0f;
    public float damage = 2.0f;

    [Header("Nav Mesh Tools")]
    public float lookRadius = 10.0f;
    [Range(0, 360)]
    public float angle = 100.0f;
    public float speed = 2.0f;
    public float stoppingDistance = 2.0f;

    [Header("Controller")]
    [SerializeField] private IAController iAController;

    private void Awake()
    {
        SendFeatures();
    }

    //Send the current features to the IAController
    private void SendFeatures()
    {
        iAController.lookRadius = this.lookRadius;
        iAController.angle = this.angle;
        iAController.speed = this.speed;
        iAController.stoppingDistance = this.stoppingDistance;
    }
}
