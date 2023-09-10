using UnityEngine;

public class Character : MonoBehaviour
{
    public bool IsAlive => currentHealth > 0;
    public bool CanAttack => nextAttackTime < Time.realtimeSinceStartup;

    [SerializeField] Rigidbody2D rb;
    [SerializeField] SpriteRenderer sprite;
    [SerializeField] AnimationController anim;

    [SerializeField] float startingHealth = 10;
    [SerializeField] float speed = 3;
    [SerializeField] float jumpForce = 200;

    private float horizontalVelocity;
    private float currentHealth;
    private bool isOnGround;
    [SerializeField] private float attackDelay = 1;
    private float nextAttackTime;

    private bool isAttacking;
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
            //anim.SetBool("IsJumping", false);
        }
    }
    public void Move(float direction)
    {
        if (!IsAlive) return;
        if (!CanAttack) return;
        horizontalVelocity = Mathf.Clamp(direction, -1, 1);
        sprite.flipX = horizontalVelocity < 0;
        anim.StartMove(horizontalVelocity != 0);
    }

    public void Jump()
    {
        if (!isOnGround) return;
        if (!IsAlive) return;
        if (!CanAttack) return;
        isOnGround = false;
        rb.AddForce(Vector2.up * jumpForce);
        anim.StartJump();
    }

    public void Attack()
    {
        if (!IsAlive) return;
        if (!CanAttack) return;
        isAttacking = true;
        anim.StartAttack();
        nextAttackTime = Time.realtimeSinceStartup + attackDelay;
    }
}
