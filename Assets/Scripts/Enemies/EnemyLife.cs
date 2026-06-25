using System.Collections;
using UnityEngine;

public class EnemyLife : Life
{
    public ParticleSystem effectPrefab;
    public Coin coinPrefab;

    private SpriteRenderer spriteRenderer;
    private ShootAtPlayer shootAtPlayer;
    private BoxCollider2D boxCollider2D;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        shootAtPlayer = GetComponent<ShootAtPlayer>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    public override void Die()
    {
        StartCoroutine(DeathEffect());
    }

    private IEnumerator DeathEffect()
    {
        SoundManager.PlaySound(SoundType.KILL_CACTUS);
        if (shootAtPlayer)
            shootAtPlayer.SetCanShoot(false);

        spriteRenderer.enabled = false;
        boxCollider2D.enabled = false;

        Instantiate(coinPrefab, transform.position, Quaternion.identity);
        ParticleSystem effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);
        effect.Play();

        yield return new WaitForSeconds(effect.main.duration);

        base.Die();
    }
}
