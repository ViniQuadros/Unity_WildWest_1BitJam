using System.Collections;
using UnityEngine;

public class EnemyLife : Life
{
    public ParticleSystem effectPrefab;
    public Coin coinPrefab;

    private SpriteRenderer spriteRenderer;
    private ShootAtPlayer shootAtPlayer;
    private ShootAtSides shootAtSides;
    private FollowPlayer followPlayer;
    private BoxCollider2D boxCollider2D;

    private Vector3 initialPosition;

    private void Awake()
    {
        initialPosition = transform.localPosition;
    }

    private void OnEnable()
    {
        transform.localPosition = initialPosition;
        currentHealth = maxHealth;
    }

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider2D = GetComponent<BoxCollider2D>();

        shootAtPlayer = GetComponent<ShootAtPlayer>();
        shootAtSides = GetComponent<ShootAtSides>();
        followPlayer = GetComponent<FollowPlayer>();
    }

    public override void Die()
    {
        StartCoroutine(DeathEffect());
    }

    private IEnumerator DeathEffect()
    {
        SoundManager.PlaySound(SoundType.KILL_CACTUS);

        if (shootAtPlayer) {
            shootAtPlayer.SetCanShoot(false);
        }
        else if (shootAtSides){
            shootAtSides.SetCanShoot(false);
        }
        else if (followPlayer){ 
            followPlayer.SetCanAttack(false);
        }

        spriteRenderer.enabled = false;
        boxCollider2D.enabled = false;

        Instantiate(coinPrefab, transform.position, Quaternion.identity);
        ParticleSystem effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);
        effect.Play();

        yield return new WaitForSeconds(effect.main.duration);

        base.Die();
    }
}
