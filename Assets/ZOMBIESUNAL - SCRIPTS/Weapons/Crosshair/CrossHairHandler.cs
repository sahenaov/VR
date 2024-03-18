using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossHairHandler : MonoBehaviour
{
    [SerializeField] new private Camera camera;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private GameObject barrel;
    [SerializeField] private GameObject crossHairPrefab;
    [SerializeField] private float distanceOffset;

    private RaycastHit hit;
    private Canvas canvas;
    private float distance;
    private Vector3 originalScale;

    private void Start()
    {
        canvas = crossHairPrefab.GetComponent<Canvas>();
        originalScale = transform.localScale;
    }

    private void Update()
    {
        if(Physics.Raycast(barrel.transform.position, barrel.transform.forward, out hit, Mathf.Infinity, layerMask))
        {
            Debug.DrawRay(barrel.transform.position, barrel.transform.forward * hit.distance, Color.blue);
            if(canvas.enabled == false) {canvas.enabled = true;}

            distance = hit.distance;
        }

        else
        {
            canvas.enabled = false;
            distance = camera.farClipPlane * 0.95f;
        }

        crossHairPrefab.transform.position = hit.point;
        crossHairPrefab.transform.LookAt(camera.transform);

        if(distance < 10.0f) 
        {
            distance *= 1 + 5*Mathf.Exp(-distance);
        }
        crossHairPrefab.transform.localScale = originalScale * distance/distanceOffset;
    }

    public void Reload()
    {
        crossHairPrefab.GetComponent<CrosshairUpdating>().Reload();
    }

    public void Reloaded()
    {
        crossHairPrefab.GetComponent<CrosshairUpdating>().Reloaded();
    }
}