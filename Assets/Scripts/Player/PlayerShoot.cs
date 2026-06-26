using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerShoot : MonoBehaviour
{
    public Transform shootPoint;
    public GameObject bulletPrefab;
    public float fireRate = .3f;
    public float reloadTime = .8f;
    public Image[] bulletImages;

    private int maxBullets = 6;
    private int currentBullets = 6;
    private bool canShoot = true;
    public bool hasUpgrade = false;

    private void Shoot()
    {
        SoundManager.PlaySound(SoundType.PLAYER_SHOOT);
        currentBullets--;
        bulletImages[currentBullets].enabled = false;

        Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        worldMousePos.z = 0;
        Vector2 direction = (worldMousePos - shootPoint.position).normalized;

        GameObject bullet = Instantiate(
            bulletPrefab,
            shootPoint.position,
            shootPoint.rotation
        );

        bullet.GetComponent<PlayerBulllets>().SetDirection(direction);

        StartCoroutine(FireRateShots());
    }

    private IEnumerator FireRateShots()
    {
        canShoot = false;
        yield return new WaitForSeconds( fireRate );
        canShoot = true;
    }

    private IEnumerator Reload()
    {
        canShoot = false;
        SoundManager.PlaySound(SoundType.RELOAD);
        yield return new WaitForSeconds( reloadTime );
        currentBullets = maxBullets;
        for (int i = 0; i < maxBullets; i++)
        {
            bulletImages[i].enabled = true;
        }
        canShoot = true;
    }

    public void IncreaseMaxBullets()
    {
        for (int i = 0; i <= maxBullets; i++)
        {
            bulletImages[i].enabled = true;
        }
        hasUpgrade = true;
        maxBullets++;
        currentBullets = maxBullets;
    }

    public void SetCanShoot(bool shoot)
    {
        canShoot = shoot;
    }

    public Transform GetShootPoint()
    {
        return shootPoint;
    }

    public void SpecialShoot(Vector2 direction)
    {
        for (int i = 0; i < 3; i++)
        {
            SoundManager.PlaySound(SoundType.PLAYER_SHOOT);

            GameObject bullet = Instantiate(
                bulletPrefab,
                shootPoint.position,
                shootPoint.rotation
            );
            bullet.GetComponent<PlayerBulllets>().SetDirection(direction);

            StartCoroutine(FireRateShots());
        }
    }

    private void OnShoot(InputValue value)
    {
        if (value.isPressed && canShoot)
        {
            if (currentBullets > 0)
            {
                Shoot();
            }
            else
            {
                StartCoroutine(Reload());
            }
        }
            
    }
}
