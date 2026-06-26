using UnityEngine;

enum EnemyStates
{
    FOLLOW,
    ATTACK,
}

public class FollowPlayer : MonoBehaviour
{
    [Header("General")]
    public float moveSpeed = 3f;
    public float attackRadius = 2f;
    public LayerMask playerMask;

    [Header("Attack")]
    public float startTimeBetweenAttack = 1f;
    private float timeBetweenAttack;

    private Rigidbody2D rb;
    private Transform target;
    private Vector2 moveDirection;
    private SpriteRenderer spriteRenderer;
    private EnemyStates currentState = EnemyStates.FOLLOW;
    private Animator animator;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, attackRadius, playerMask);
        currentState = hit ? EnemyStates.ATTACK : EnemyStates.FOLLOW;

        switch (currentState)
        {
            case EnemyStates.FOLLOW:
                Follow();
                break;
            case EnemyStates.ATTACK:
                Attack(hit);
                break;
        }
    }

    void Follow()
    {
        if (target)
        {
            moveDirection = (target.position - transform.position).normalized;

            if (moveDirection.x < 0) spriteRenderer.flipX = false;
            else if (moveDirection.x > 0) spriteRenderer.flipX = true;
        }
    }

    void Attack(Collider2D player)
    {
        moveDirection = Vector2.zero;

        if (timeBetweenAttack <= 0)
        {
            animator.SetTrigger("Attack");
            player.GetComponent<PlayerLife>().TakeDamage();
            timeBetweenAttack = startTimeBetweenAttack;
        }
        else
        {
            timeBetweenAttack -= Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = moveDirection * moveSpeed;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }
}