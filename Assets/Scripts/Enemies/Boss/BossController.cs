using System.Collections;
using UnityEngine;

public class BossController : MonoBehaviour
{
    [Header("Attacks")]
    public float minColdownTime = 0.5f;
    public float maxCooldowTime = 2.0f;

    [Header("Attack One")]
    public Transform[] attackPoints;
    public GameObject spikes;

    [Header("Attack Two")]
    public float dashSpeed = 5f;
    public float dashDuration = 1.5f;
    public float pauseBetweenDashes = 0.3f;

    private enum BossState
    {   
        Idle, 
        AttackOne, 
        AttackTwo, 
        Cooldown 
    }
    private BossState currentState;

    private Transform player;
    private Animator animator;
    private Rigidbody2D rb;

    private void OnEnable()
    {
        StartCoroutine(BossBehaviour());
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(BossBehaviour());
    }

    private IEnumerator BossBehaviour()
    {
        while (true)
        {
            switch (currentState)
            {
                case BossState.Idle:
                    yield return StartCoroutine(ChooseAttack());
                    break;

                case BossState.AttackOne:
                    yield return StartCoroutine(AttackOne());
                    currentState = BossState.Cooldown;
                    break;

                case BossState.AttackTwo:
                    yield return StartCoroutine(AttackTwo());
                    currentState = BossState.Cooldown;
                    break;

                case BossState.Cooldown:
                    float cooldownTime = Random.Range(minColdownTime, maxCooldowTime);
                    yield return new WaitForSeconds(cooldownTime);
                    currentState = BossState.Idle;
                    break;
            }

            yield return null;
        }
    }

    private IEnumerator ChooseAttack()
    {
        int choice = Random.Range(0, 2);
        currentState = choice == 0 ? BossState.AttackOne : BossState.AttackTwo;
        yield return null;
    }

    private IEnumerator AttackOne()
    {
        animator.SetTrigger("AttackOne");

        yield return new WaitForSeconds(0.6f);

        for (int i = 0; i < attackPoints.Length; i++)
        {
            GameObject bullet = Instantiate(spikes, attackPoints[i].position, attackPoints[i].rotation);
            bullet.GetComponent<Bullets>().SetSpeed(10f);
            bullet.GetComponent<Bullets>().SetDirection(attackPoints[i].transform.right);
        }

        yield return new WaitForSeconds(1f);
    }

    private IEnumerator AttackTwo()
    {
       

        for (int i = 0; i < 3; i++)
        {
            animator.SetTrigger("AttackTwo");
            Vector2 dashDirection = (player.position - transform.position).normalized;

            float elapsed = 0f;

            while (elapsed < dashDuration)
            {
                rb.linearVelocity = dashDirection.normalized * dashSpeed;
                elapsed += Time.deltaTime;
                yield return null;
            }

            rb.linearVelocity = Vector2.zero;
            yield return new WaitForSeconds(pauseBetweenDashes);
        }

        yield return new WaitForSeconds(1f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerLife>().TakeDamage();
        }
    }
}