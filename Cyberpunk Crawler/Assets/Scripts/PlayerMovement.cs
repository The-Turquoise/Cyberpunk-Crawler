using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float jumpGravity;
    [SerializeField] private float fallGravity;
    
    private float horizontalInput;
    [SerializeField] private bool isOnGround;
    private void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        if (horizontalInput == -1) sprite.flipX = true;
        if (horizontalInput == 1) sprite.flipX = false;

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            isOnGround = false;
            rb.AddForce(Vector2.up * jumpForce);
        }

        if (rb.velocity.y > 0) rb.gravityScale = jumpGravity;
        else rb.gravityScale = fallGravity;
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
