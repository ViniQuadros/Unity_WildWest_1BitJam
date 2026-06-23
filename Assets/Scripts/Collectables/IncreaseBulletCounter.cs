using UnityEngine;

public class IncreaseBulletCounter : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerShoot playerShoot = collision.GetComponent<PlayerShoot>();
            if (playerShoot != null)
            {
                playerShoot.IncreaseMaxBullets();
                Destroy(gameObject);
            }
        }
    }
}
