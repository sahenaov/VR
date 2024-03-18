using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetHandler : MonoBehaviour
{
    [Range(0, 200)]
    [SerializeField] private float health = 200f;

    public void GetDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Die");
    }
}
