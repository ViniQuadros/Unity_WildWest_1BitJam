using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public float moveSpeed = 3f;

    private Rigidbody2D rb;
    private Transform target;
    private Vector2 moveDirection;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (target)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            moveDirection = direction;

            if (moveDirection.x < 0)
                spriteRenderer.flipX = false;
            else if (moveDirection.x > 0)
                spriteRenderer.flipX = true;
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed;
    }
}
