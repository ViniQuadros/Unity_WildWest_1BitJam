using System.Collections;
using UnityEngine;

public class ShootAtPlayer : MonoBehaviour
{
    public Transform shootPoint;
    public GameObject bulletPrefab;
    public float minFireRate = 1f;
    public float maxFireRate = 5f;

    private Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        if (shootPoint == null)
            shootPoint = transform;

        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        while (true)
        {
            Vector2 direction = player.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            GameObject bullet = Instantiate(
                bulletPrefab, 
                shootPoint.position, 
                Quaternion.Euler(0, 0, angle)
            );
            bullet.GetComponent<Bullets>().SetSpeed(1f);
            bullet.GetComponent<Bullets>().SetDirection(direction);

            Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), GetComponent<Collider2D>());

            float fireRate = Random.Range(minFireRate, maxFireRate);

            yield return new WaitForSeconds(fireRate);
        }
    }
}