using UnityEngine;

public class Bullets : MonoBehaviour
{
    public float bulletSpeed = 10.0f;

    private Rigidbody2D rb;

    void Start()
    {
        Destroy(gameObject, 5.0f);
    }

    public void SetDirection(Vector2 direction)
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = direction * bulletSpeed;
    }

    public void SetSpeed(float speed)
    {
        bulletSpeed = speed;
    }
}
