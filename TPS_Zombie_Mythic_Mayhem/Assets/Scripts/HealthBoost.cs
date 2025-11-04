using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBoost : MonoBehaviour
{
    [Header("Health Boost Variables")]
    public PlayerScript player;
    private float healthToGive = 120f;
    private float radius = 2.5f;

    //[Header("Sounds")]
    //public AudioSource audioSource;
    //public AudioClip HealthBoostSound;

    [Header("Healthbox Animator")]
    public Animator animator;

    private void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) <= radius)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                animator.SetBool("Open", true);
                player.presentHealth = player.presentHealth +  healthToGive;

                //audioSource.PlayOneShot(HealthBoostSound);

                Object.Destroy(gameObject, 1.5f);
            }
        }
    }
}
