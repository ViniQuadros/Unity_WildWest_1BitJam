using UnityEngine;

public class Life : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth = 3;

    protected bool isDead = false;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public virtual void TakeDamage()
    {
        if (!isDead)
        {
            currentHealth--;
            if (currentHealth <= 0)
            {
                isDead = true;
                Die();
            }
        }
    }

    public virtual void Die()
    {
        Destroy(gameObject);
    }
}
