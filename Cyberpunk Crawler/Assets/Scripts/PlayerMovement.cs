using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] PlayerAnimations anim;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private SpriteRenderer sprite;


    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float jumpGravity;
    [SerializeField] private float fallGravity;
    
    private float horizontalInput;
    private bool isOnGround;
    private void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");

        //Flip the player sprite depending on which way the player is moving
        if (horizontalInput == -1) sprite.flipX = true;
        if (horizontalInput == 1) sprite.flipX = false;

        //Play the run animation if player is moving
        if (horizontalInput != 0) anim.SetAnimationStatus("IsMoving", true);
        else anim.SetAnimationStatus("IsMoving", false);

        //Jump when player presses Space key and is on ground
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            isOnGround = false;
            rb.AddForce(Vector2.up * jumpForce);
        }

        //Increase gravity scale if the player is off the ground
        rb.gravityScale = isOnGround ? jumpGravity : fallGravity;

        //Plays the jump animation
        anim.SetAnimationStatus("IsJumping", !isOnGround);
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalInput * speed ,rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isOnGround = true;
        }
    }
}
