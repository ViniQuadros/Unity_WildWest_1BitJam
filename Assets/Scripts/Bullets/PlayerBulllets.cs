using UnityEngine;

public class PlayerBulllets : Bullets
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") || collision.CompareTag("BreakableWall"))
        {
            collision.GetComponent<Life>().TakeDamage();
            Destroy(gameObject);
        }

        if (collision.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}
