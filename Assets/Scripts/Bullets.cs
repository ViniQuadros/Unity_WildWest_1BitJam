using UnityEngine;

public class Bullets : MonoBehaviour
{
    public float bulletSpeed = 10.0f;

    private Rigidbody2D rb;

    void Start()
    {
        Destroy(gameObject, 5.0f);
    }

    public void SetDirection(Vector2 direction)
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = direction * bulletSpeed;
    }

    public void SetSpeed(float speed)
    {
        bulletSpeed = speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerLife>().TakeDamage();
            Destroy(gameObject);
        }

        if (collision.CompareTag("Enemy") || collision.CompareTag("BreakableWall"))
        {
            collision.GetComponent<Life>().TakeDamage();
            Destroy(gameObject);
        }
    }
}
