using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : Life
{
    public Hearts[] uiHearts;

    public override void TakeDamage()
    {
        uiHearts[currentHealth - 1].LoseHeart();
        base.TakeDamage();
    }

    public override void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
