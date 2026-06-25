using System.Collections;
using UnityEngine;

public class ShootAtSides : MonoBehaviour
{
    public Transform[] shootPoints;
    public GameObject bulletPrefab;
    public float fireInterval = 1.5f;

    void Start()
    {
        StartCoroutine(ShootSides());
    }

    private IEnumerator ShootSides()
    {
        while (true)
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