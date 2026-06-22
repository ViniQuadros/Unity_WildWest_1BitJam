using UnityEngine;
using UnityEngine.InputSystem;

public class FollowMouse : MonoBehaviour
{
    public Transform playerTransform;

    void Update()
    {
        Vector3 mouseScreen = Mouse.current.position.ReadValue();
        mouseScreen.z = -Camera.main.transform.position.z;
        Vector2 mouseWorld = Camera.main.ScreenToWorldPoint(mouseScreen);

        Vector2 direction = mouseWorld - (Vector2)playerTransform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, angle);

        bool mouseOnLeft = mouseWorld.x < playerTransform.position.x;
        float scaleX = mouseOnLeft ? -1f : 1f;
        playerTransform.localScale = new Vector3(scaleX, 1f, 1f);
    }
}