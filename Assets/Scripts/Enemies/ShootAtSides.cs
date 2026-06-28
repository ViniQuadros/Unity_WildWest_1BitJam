using System.Collections;
using UnityEngine;

public class ShootAtSides : MonoBehaviour
{
    public Transform[] shootPoints;
    public GameObject bulletPrefab;
    public float fireInterval = 1.5f;

    private bool canShoot = true;
    private Coroutine shootCoroutine;

    private void OnEnable()
    {
        canShoot = true;
        shootCoroutine = StartCoroutine(ShootSides());
    }

    public void SetCanShoot(bool canEnemyShoot)
    {
        canShoot = canEnemyShoot;

        if (!canShoot && shootCoroutine != null)
            StopCoroutine(shootCoroutine);
    }

    private IEnumerator ShootSides()
    {
        while (canShoot)
        {
            foreach (Transform shootPoint in shootPoints)
            {
                GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
                bullet.GetComponent<EnemyBullets>().SetDirection(shootPoint.right);
                Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            }

            SoundManager.PlaySound(SoundType.ENEMY_SHOOT);
            yield return new WaitForSeconds(fireInterval);
        }
    }
}