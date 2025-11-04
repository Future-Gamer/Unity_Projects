using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [Header("Player Movement")]
    public float playerSpeed = 1.9f;
    public float playerSprint = 3f;

    [Header("Player Health Things")]
    public float playerHealth = 200f;
    public float presentHealth;
    public GameObject playerDamage;
    public HealthBar healthBar;

    [Header("Player Script Cameras")]
    public Transform playerCamera;
    public GameObject endGameMenuUI;

    [Header("Player Animator and Gravity")]
    public CharacterController cC;
    public float gravity = -9.81f;
    public Animator animator;

    [Header("Player Jumping and Velocity")]
    public float turnCalmTime = 0.1f;
    float turnCalmVelocity;
    public float jumpRange = 1f;
    Vector3 velocity;
    public Transform surfaceCheck;
    bool onSurface;
    public float surfaceDistance = 0.4f;
    public LayerMask surfaceMask;



    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        presentHealth = playerHealth; // Initialize current health to maximum health at the start
        healthBar.GiveFullHealth(playerHealth); // Set the health bar to full health at the start
    }

    private void Update()
    {
        onSurface = Physics.CheckSphere(surfaceCheck.position, surfaceDistance, surfaceMask); // Check if the player is on the ground
        if (onSurface && velocity.y < 0)
        {
            velocity.y = -2f; // Reset downward velocity when on the ground
        }

        velocity.y += gravity * Time.deltaTime; // Apply gravity to the player's vertical velocity
        cC.Move(velocity * Time.deltaTime); // Move the player based on vertical velocity


        playerMove();
        Jump();
        Sprint();
        HealthUpdate();
    }


    void HealthUpdate()
    {
        healthBar.SetHealth(presentHealth);
    }


    void playerMove()
    {
        float horizontal_axis = Input.GetAxis("Horizontal"); // A/D or Left/Right Arrow Keys
        float vertical_axis = Input.GetAxis("Vertical"); // W/S or Up/Down Arrow Keys

        Vector3 direction = new Vector3(horizontal_axis, 0f, vertical_axis).normalized; // Direction vector based on input

        if (direction.magnitude >= 0.1f)
        {
            animator.SetBool("Idle", false);
            animator.SetBool("Walk", true);
            animator.SetBool("Running", false);
            

            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + playerCamera.eulerAngles.y; // Calculate the target angle based on input and camera orientation
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnCalmVelocity, turnCalmTime); // Smoothly rotate the player
            transform.rotation = Quaternion.Euler(0f, angle,0f); // Rotate the player to face the movement direction

            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward; // Calculate the move direction based on the target angle
            cC.Move(moveDirection.normalized * playerSpeed * Time.deltaTime); // Move the player
        }
        else
        {
            animator.SetBool("Idle", true);
            animator.SetBool("Walk", false);
            animator.SetBool("Running", false);
            animator.SetBool("Rifle_Walk", false);
            animator.SetBool("Rifle_Aim", false);
        }
    }


    void Jump()
    {
        if (Input.GetButtonDown("Jump") && onSurface)
        {
            animator.SetBool("Idle", false);
            animator.SetTrigger("Jump");

            velocity.y = Mathf.Sqrt(jumpRange * -2f * gravity); // Calculate the jump velocity based on jump height and gravity
        }
        else
        {
            animator.SetBool("Idle", true);
            animator.ResetTrigger("Jump");
        }
    }


    void Sprint()
    {
        if (Input.GetButton("Sprint") && Input.GetKey(KeyCode.W) || Input.GetButton("Sprint") && Input.GetKey(KeyCode.UpArrow) && onSurface)
        {
            float horizontal_axis = Input.GetAxis("Horizontal"); // A/D or Left/Right Arrow Keys
            float vertical_axis = Input.GetAxis("Vertical"); // W/S or Up/Down Arrow Keys

            Vector3 direction = new Vector3(horizontal_axis, 0f, vertical_axis).normalized; // Direction vector based on input

            if (direction.magnitude >= 0.1f)
            {
                animator.SetBool("Walk", false);
                animator.SetBool("Running", true);


                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + playerCamera.eulerAngles.y; // Calculate the target angle based on input and camera orientation
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnCalmVelocity, turnCalmTime); // Smoothly rotate the player
                transform.rotation = Quaternion.Euler(0f, angle, 0f); // Rotate the player to face the movement direction

                Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward; // Calculate the move direction based on the target angle
                cC.Move(moveDirection.normalized * playerSprint * Time.deltaTime); // Move the player
            }
            else
            {
                animator.SetBool("Walk", true);
                animator.SetBool("Running", false);
            }
        }
    }


    public void PlayerHitDamage(float takeDamage)
    {
        presentHealth -= takeDamage; // Reduce current health by the damage taken
        StartCoroutine(PlayerDamage());

        healthBar.SetHealth(presentHealth); // Update the health bar to reflect the new health value

        if (presentHealth <= 0)
        {
            PlayerDie();
        }

    }


    private void PlayerDie()
    {
        endGameMenuUI.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Object.Destroy(gameObject, 1.0f); // Destroy the player object after a delay of 1 second
    }


    IEnumerator PlayerDamage()
    {
        playerDamage.SetActive(true);
        yield return new WaitForSeconds(2f);
        playerDamage.SetActive(false);
    }

}
