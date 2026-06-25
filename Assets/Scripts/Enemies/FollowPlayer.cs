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
    public float chaseRadius = 10f;
    public float attackRadius = 5f;
    public LayerMask playerMask;

    [Header("Attack")]
    public Transform attackPos;
    public float attackRange = 3f;
    public float startTimeBetweenAttack;
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
                Attack(); 
                break;
        }

    }

    void Follow()
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

    void Attack()
    {
        if (timeBetweenAttack <= 0)
        {
            moveDirection = Vector3.zero;

            Collider2D player = Physics2D.OverlapCircle(attackPos.position, attackRange, playerMask);
            if (player != null)
            {
                animator.SetTrigger("Attack");
                player.GetComponent<PlayerLife>().TakeDamage();
                timeBetweenAttack = startTimeBetweenAttack;
            }
        }
        else
            timeBetweenAttack -= Time.deltaTime;
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, chaseRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
