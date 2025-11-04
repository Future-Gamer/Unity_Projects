using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int Health = 10;

    // Add the OnDestroyed event
    public event Action<GameObject> OnDestroyed;

    public void TakeDamage(float damage)
    {
        Health -= (int)damage;
        if (Health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Invoke the event before destroying the object
        OnDestroyed?.Invoke(gameObject);
        Destroy(gameObject);
    }
}
