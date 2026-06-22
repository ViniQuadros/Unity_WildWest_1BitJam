using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    public Transform shootPoint;
    public GameObject bulletPrefab;

    private void Shoot()
    {
        Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        worldMousePos.z = 0;
        Vector2 direction = (worldMousePos - shootPoint.position).normalized;

        GameObject bullet = Instantiate(
            bulletPrefab,
            shootPoint.position,
            Quaternion.identity
        );

        bullet.GetComponent<Bullets>().SetDirection(direction);
    }

    private void OnShoot(InputValue value)
    {
        if (value.isPressed)
            Shoot();
    }
}
