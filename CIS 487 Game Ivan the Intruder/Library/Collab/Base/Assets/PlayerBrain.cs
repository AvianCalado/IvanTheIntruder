using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBrain : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float jumpForce = 1.5f;
    public bool isGrounded;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rigidBody;
    public static AudioClip jump_sound;
    public static AudioClip hit_enemy;
    public static AudioClip land_sound;
    private AudioSource audioSrc;

    // Checks which powerup is in use by the player
    public int PUinUse;

    // Start is called before the first frame update
    void Start()
    {
        //Initialize animator, spriteRenderer, and rigidBody
        animator = gameObject.GetComponent<Animator>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        rigidBody = GetComponent<Rigidbody2D>();
        jump_sound = Resources.Load<AudioClip>("Jump");
        hit_enemy = Resources.Load<AudioClip>("HitEnemy");
        land_sound = Resources.Load<AudioClip>("jumpland");
        audioSrc = GetComponent<AudioSource>();
        PUinUse = -1;
    }


    // Update is called once per frame
    void Update()
    {   
        //Check if player is jumping
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
        //Get player horizontal movement input
        float horizontalMovement = Input.GetAxis("Horizontal");
        //Create new vector based on player input
        Vector3 movement = new Vector3(horizontalMovement, 0f, 0f);
        //If vector > 0 player x position will update and isWalking is true
        transform.position += movement * Time.deltaTime * movementSpeed;
        if (horizontalMovement != 0)
        {
            animator.SetBool("isWalking", true);
            //Flip character to walking direction
            if (horizontalMovement < 0)
            {
                spriteRenderer.flipX = true;
            }
            else
            {
                spriteRenderer.flipX = false;
            }
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }

    void Jump()
    {
        //Only let the player jump if they're on the ground
        if (isGrounded)
        {
            audioSrc.PlayOneShot(jump_sound);
            rigidBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //If player is colliding with ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            audioSrc.volume = 0.5f;
            audioSrc.PlayOneShot(land_sound);
            isGrounded = true;
        }

        // if player has crowbar in inventory they can destroy enemy
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //if player has crowbar , destroy opponent and adjust volume to play sound effect
            if(PUinUse == 0)
            {
                audioSrc.volume = 0.15f;
                audioSrc.PlayOneShot(hit_enemy);
                Destroy(collision.gameObject);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //If player is not collided with ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

}
