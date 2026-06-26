using UnityEngine;

public class CheckEnemies : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject wallBlocker;
    public Vector2 boxSize;
    public LayerMask enemy;

    void Update()
    {
        Collider2D[] enemies = Physics2D.OverlapBoxAll(mainCamera.transform.position, boxSize, 0, enemy);

        if (enemies.Length > 0)
        {
            wallBlocker.SetActive(true);
        }
        else
        {
            wallBlocker.SetActive(false);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.darkGreen;
        Gizmos.DrawWireCube(mainCamera.transform.position, new Vector3(boxSize.x, boxSize.y, 0));
    }
}
