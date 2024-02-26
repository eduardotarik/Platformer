// Importing necessary namespaces
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Defining a class named Player_Movement that inherits from MonoBehaviour
public class Player_Movement : MonoBehaviour
{
    // Private variables for Rigidbody2D, BoxCollider2D, SpriteRenderer, Animator
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;

    // Serialized field to specify the ground layer for jumping detection
    [SerializeField] private LayerMask jumpableGround;

    // Private variables for horizontal movement, move speed, and jump force
    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;

    // Enum to represent different movement states
    private enum MovementState { idle, running, jumping, falling }

    // Serialized field for the jump sound effect
    [SerializeField] private AudioSource jumpSoundEffect;

    // Start is called before the first frame update
    private void Start()
    {
        // Getting component references during initialization
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        // Getting horizontal input for movement
        dirX = Input.GetAxisRaw("Horizontal");

        // Setting the velocity for horizontal movement
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        // Checking for jump input and whether the player is grounded
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            // Playing the jump sound effect
            jumpSoundEffect.Play();

            // Applying vertical velocity for jumping
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        // Updating the animation state based on player movement
        UpdateAnimationState();
    }

    // Method to update the player's animation state
    private void UpdateAnimationState()
    {
        // Variable to store the current movement state
        MovementState state;

        // Checking horizontal input for running state and flipping the sprite accordingly
        if (dirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        // Checking vertical velocity for jumping and falling states
        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        // Updating the Animator with the current movement state
        anim.SetInteger("state", (int)state);
    }

    // Method to check if the player is grounded
    private bool IsGrounded()
    {
        // Using Physics2D.BoxCast to check for ground within a small distance
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
