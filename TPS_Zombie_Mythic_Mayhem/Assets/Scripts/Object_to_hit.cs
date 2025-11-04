using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_to_hit : MonoBehaviour
{
    public float objectHealth = 30f;

    public void ObjectHitDamage(float amount)
    {
        objectHealth -= amount;

        if (objectHealth <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
