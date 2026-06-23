using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : Life
{
    public Hearts[] uiHearts;
    public PlayerMovement playerMoveMovement;
    public PlayerAnimations playerAnimations;

    public override void TakeDamage()
    {
        if (!isDead)
        {
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
        playerMoveMovement.SetCanMove(false);
        playerAnimations.PlayDeathAnim();

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
