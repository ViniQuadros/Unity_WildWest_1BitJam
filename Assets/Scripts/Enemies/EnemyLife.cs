using System.Collections;
using UnityEngine;

public class EnemyLife : Life
{
    public ParticleSystem effectPrefab;

    private SpriteRenderer spriteRenderer;
    private ShootAtPlayer shootAtPlayer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        shootAtPlayer = GetComponent<ShootAtPlayer>();
    }

    public override void Die()
    {
        StartCoroutine(DeathEffect());
    }

    private IEnumerator DeathEffect()
    {
        shootAtPlayer.SetCanShoot(false);

        spriteRenderer.enabled = false;
        ParticleSystem effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);
        effect.Play();

        yield return new WaitForSeconds(effect.main.duration);

        base.Die();
    }
}
