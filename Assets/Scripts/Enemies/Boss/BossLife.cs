using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossLife : Life
{
    public ParticleSystem effectPrefab;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public override void TakeDamage()
    {
        base.TakeDamage();
    }

    public override void Die()
    {
        StartCoroutine("BossDeath");
    }

    public void HealBoss()
    {
        currentHealth = maxHealth;
    }

    private IEnumerator BossDeath()
    {
        SoundManager.PauseBackgroundSong();
        SoundManager.PlaySound(SoundType.KILL_CACTUS);
        spriteRenderer.enabled = false;
        ParticleSystem effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);
        effect.Play();

        yield return new WaitForSeconds(effect.main.duration);

        SceneManager.LoadScene("FinalScene");
    }
}
