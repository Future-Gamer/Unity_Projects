using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpawnZombie : MonoBehaviour
{
    [Header("Zombie Health and Damage")]
    private float zombieHealth = 100f;
    private float presentHealth;
    public float giveDamage = 5f;
    public HealthBar healthBar;

    [Header("Zombie Things")]
    public UnityEngine.AI.NavMeshAgent zombieAgent;
    public Transform LookPoint;
    public Camera AttackingRaycastArea;
    public Transform playerBody;
    public LayerMask PlayerLayer;

    [Header("Zombie Standing Variable")]
    public float zombieSpeed;

    [Header("Zombie Attacking Variable")]
    public float timeBetweenAttacks;
    bool previouslyAttack;

    [Header("Zombie Animation")]
    public Animator animator;

    [Header("Zombie Mood/States")]
    public float visionRadius;
    public float attackingRadius;
    public bool playerInVisionRadius;
    public bool playerInAttackingRadius;


    private void Awake()
    {
        zombieAgent = GetComponent<NavMeshAgent>(); // Get the NavMeshAgent component attached to the zombie
        //LookPoint = GameObject.Find("LookPoint").transform;
        presentHealth = zombieHealth; // Initialize current health to maximum health at the start
        healthBar.GiveFullHealth(zombieHealth);
    }

    private void Update()
    {
        playerInVisionRadius = Physics.CheckSphere(transform.position, visionRadius, PlayerLayer);
        playerInAttackingRadius = Physics.CheckSphere(transform.position, attackingRadius, PlayerLayer);

        if (!playerInVisionRadius && !playerInAttackingRadius) Idle();
        if (playerInVisionRadius && !playerInAttackingRadius) PersuePlayer();
        if (playerInAttackingRadius && playerInVisionRadius) AttackPlayer();
    }


    private void Idle()
    {
        zombieAgent.SetDestination(transform.position);
        animator.SetBool("Idle", true);
        animator.SetBool("Running", false);

    }


    private void PersuePlayer()
    {
        if (zombieAgent.SetDestination(playerBody.position))
        {
            // Animations
            animator.SetBool("Idle", false);
            animator.SetBool("Running", true);
            animator.SetBool("Attacking", false);

        }
    }


    private void AttackPlayer()
    {
        zombieAgent.SetDestination(transform.position);
        transform.LookAt(LookPoint);
        if (!previouslyAttack)
        {
            RaycastHit hitInfo;
            if (Physics.Raycast(AttackingRaycastArea.transform.position, AttackingRaycastArea.transform.forward, out hitInfo, attackingRadius))
            {
                Debug.Log("Attacking" + hitInfo.transform.name);

                PlayerScript playerBody = hitInfo.transform.GetComponent<PlayerScript>();

                if (playerBody != null)
                {
                    playerBody.PlayerHitDamage(giveDamage);

                }

                // Animations
                animator.SetBool("Attacking", true);
                animator.SetBool("Running", false);

            }

            previouslyAttack = true;
            Invoke(nameof(ActiveAttacking), timeBetweenAttacks);
        }
    }


    private void ActiveAttacking()
    {
        previouslyAttack = false;
    }

    public void ZombieHitDamage(float takeDamage)
    {
        presentHealth -= takeDamage; // Reduce current health by the damage taken

        healthBar.SetHealth(presentHealth);

        if (presentHealth <= 0)
        {
            // Animations
            animator.SetBool("Died", true);
            ZombieDie();
        }
    }

    private void ZombieDie()
    {
        zombieAgent.SetDestination(transform.position);
        zombieSpeed = 0f;
        attackingRadius = 0f;
        visionRadius = 0f;
        playerInAttackingRadius = false;
        playerInVisionRadius = false;
        Object.Destroy(gameObject, 5.0f); // Destroy the player object after a delay of 1 second
    }
}
