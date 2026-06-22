using UnityEngine;

public class Life : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth = 3;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage()
    {
        currentHealth--;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
