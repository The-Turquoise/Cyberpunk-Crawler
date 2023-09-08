using UnityEngine;

public class Character : MonoBehaviour
{
    public bool IsAlive => currentHealth > 0;

    [SerializeField] Rigidbody2D rb;
    [SerializeField] SpriteRenderer sprite;
    [SerializeField] Animator anim;

    [SerializeField] float startingHealth = 10;
    [SerializeField] float speed = 3;
    [SerializeField] float jumpForce = 200;

    private float horizontalVelocity;
    private float currentHealth;
    private bool isOnGround;
    private void OnEnable()
    {
        currentHealth = startingHealth;
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalVelocity * speed, rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isOnGround = true;
            anim.SetBool("IsJumping", false);
        }
    }
    public void Move(float direction)
    {
        horizontalVelocity = Mathf.Clamp(direction, -1, 1);
        sprite.flipX = horizontalVelocity < 0;
        anim.SetBool("IsRunning", horizontalVelocity != 0);
    }

    public void Jump()
    {
        if (!isOnGround) return;
        if (!IsAlive) return;
        rb.AddForce(Vector2.up * jumpForce);
        anim.SetBool("IsJumping", true);
    }
}
