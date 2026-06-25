using System.Collections;
using UnityEngine;

public class ShootAtPlayer : MonoBehaviour
{
    public Transform shootPoint;
    public GameObject bulletPrefab;
    public float minFireRate = 1f;
    public float maxFireRate = 5f;

    private Transform player;
    private bool canShoot = true;
    private Coroutine shootCoroutine;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        if (shootPoint == null)
            shootPoint = transform;

        shootCoroutine = StartCoroutine(Shoot());
    }

    public void SetCanShoot(bool canEnemyShoot)
    {
        canShoot = canEnemyShoot;

        if (!canShoot && shootCoroutine != null)
            StopCoroutine(shootCoroutine);
    }

    private IEnumerator Shoot()
    {
        while (canShoot)
        {
            float fireRate = Random.Range(minFireRate, maxFireRate);
            yield return new WaitForSeconds(fireRate);
            SoundManager.PlaySound(SoundType.ENEMY_SHOOT);
            Vector2 direction = player.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            GameObject bullet = Instantiate(
                bulletPrefab, 
                shootPoint.position, 
                Quaternion.Euler(0, 0, angle)
            );
            bullet.GetComponent<EnemyBullets>().SetDirection(direction);

            Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }
}