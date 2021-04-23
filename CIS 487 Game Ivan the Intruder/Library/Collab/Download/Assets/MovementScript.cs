using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float jumpForce = 1.5f;
    public bool isGrounded;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        //Initialize animator, spriteRenderer, and rigidBody
        animator = gameObject.GetComponent<Animator>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        rigidBody = GetComponent<Rigidbody2D>();
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
            rigidBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //If player is colliding with ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
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
