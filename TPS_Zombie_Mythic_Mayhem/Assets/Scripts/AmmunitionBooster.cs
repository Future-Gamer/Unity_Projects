using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmunitionBooster : MonoBehaviour
{
    [Header("Ammo Boost Variables")]
    //public PlayerScript player;
    public Rifle rifle;
    private int magToGive = 35;
    private float radius = 2.5f;

    //[Header("Sounds")]
    //public AudioSource audioSource;
    //public AudioClip AmmoBoostSound;

    [Header("Healthbox Animator")]
    public Animator animator;

    private void Update()
    {
        if (Vector3.Distance(transform.position, rifle.transform.position) <= radius)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                animator.SetBool("Open", true);
                rifle.mag = magToGive; 

                //audioSource.PlayOneShot(AmmoBoostSound);

                Object.Destroy(gameObject, 1.5f);
            }
        }
    }
}
