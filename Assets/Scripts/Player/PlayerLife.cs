using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : Life
{
    public Hearts[] uiHearts;
    public PlayerMovement playerMoveMovement;
    public PlayerAnimations playerAnimations;

    public void Heal()
    {
        uiHearts[currentHealth].GainHeart();
        currentHealth++;
    }

    public bool CanHeal()
    {
        return currentHealth < maxHealth;
    }

    public override void TakeDamage()
    {
        if (!isDead)
        {
            SoundManager.PlaySound(SoundType.HURT_PLAYER);
            uiHearts[currentHealth - 1].LoseHeart();
            base.TakeDamage();
        }
    }

    public override void Die()
    {
        StartCoroutine(DeathRoutine());
    }

    private IEnumerator DeathRoutine()
    {
        SoundManager.PlaySound(SoundType.KILL_PLAYER);
        playerMoveMovement.SetCanMove(false);
        playerAnimations.PlayDeathAnim();

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
