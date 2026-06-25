using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : Life
{
    public Hearts[] uiHearts;
    public PlayerMovement playerMoveMovement;
    public PlayerAnimations playerAnimations;

    private void Start()
    {
        SoundManager.PlayBackgroundSong();
    }

    public void Heal()
    {
        if (currentHealth < maxHealth)
        {
            uiHearts[currentHealth].GainHeart();
            currentHealth++;
        }
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
        SoundManager.PauseBackgroundSong();
        SoundManager.PlaySound(SoundType.KILL_PLAYER);
        playerMoveMovement.SetCanMove(false);
        playerAnimations.PlayDeathAnim();
        yield return new WaitForSeconds(SoundManager.GetSoundLength(SoundType.KILL_PLAYER));
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void IncreaseMaxLife()
    {
        for (int i = 0; i < maxHealth; i++)
        {
            uiHearts[i].GainHeart();
        }
        maxHealth++;
        currentHealth = maxHealth;
        uiHearts[maxHealth - 1].GetNewHeart();
    }
}
