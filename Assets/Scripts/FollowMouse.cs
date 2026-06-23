using UnityEngine;
using UnityEngine.InputSystem;

public class FollowMouse : MonoBehaviour
{
    public Transform playerTransform;
    public float orbitDistance = 0.5f;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Vector3 mouseScreen = Mouse.current.position.ReadValue();
        mouseScreen.z = -Camera.main.transform.position.z;
        Vector2 mouseWorld = Camera.main.ScreenToWorldPoint(mouseScreen);

        Vector2 direction = (mouseWorld - (Vector2)playerTransform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Position pistol around the player in the direction of the mouse
        transform.position = (Vector2)playerTransform.position + direction * orbitDistance;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        bool mouseOnLeft = mouseWorld.x < playerTransform.position.x;
        spriteRenderer.flipY = mouseOnLeft;
    }
}