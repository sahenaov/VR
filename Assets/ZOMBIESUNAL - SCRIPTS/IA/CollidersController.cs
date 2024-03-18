using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollidersController : MonoBehaviour
{
    [SerializeField] Collider colliderLeftHand, colliderRightHand;

    private void Start()
    {
        colliderLeftHand.enabled = false;
        colliderRightHand.enabled = false;
    }

    public void EnableColliderLeftHand()
    {
        colliderLeftHand.enabled = true;
    }

    public void EnableColliderRightHand()
    {
        colliderRightHand.enabled = true;
    }

    public void DisableColliderLeftHand()
    {
        colliderLeftHand.enabled = false;
    }

    public void DisableColliderRightHand()
    {
        colliderRightHand.enabled = false;
    }
}
