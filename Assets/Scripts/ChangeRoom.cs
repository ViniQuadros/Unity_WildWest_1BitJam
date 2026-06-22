using System.Collections;
using UnityEngine;

public class ChangeRoom : MonoBehaviour
{
    public Transform cameraTransform;
    public Transform target;
    public float transitionSpeed = 10f;

    private BoxCollider2D boxCollider;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            StartCoroutine(MoveCamera());
    }

    private IEnumerator MoveCamera()
    {
        Vector3 destination = new Vector3(target.position.x, target.position.y, cameraTransform.position.z);

        while (Vector3.Distance(cameraTransform.position, destination) > 0.01f)
        {
            cameraTransform.position = Vector3.MoveTowards(cameraTransform.position, destination, transitionSpeed * Time.deltaTime);
            yield return null;
        }

        cameraTransform.position = destination;
    }

    private void OnDrawGizmos()
    {
        if (boxCollider == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawCube(transform.position, new Vector3(boxCollider.size.x, boxCollider.size.y, 0));
    }
}