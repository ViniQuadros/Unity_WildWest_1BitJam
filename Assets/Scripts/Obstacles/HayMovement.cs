using System.Collections;
using UnityEngine;

public class HayMovement : MonoBehaviour
{
    public float moveDistance = 5f;
    public float movementSpeed = 5.0f;
    public float rotation = 10f;

    private Vector3 pointA;
    private Vector3 pointB;

    void Start()
    {
        pointA = transform.position;
        pointB = transform.position + Vector3.up * moveDistance;

        StartCoroutine(MoveUpDown());
    }

    private void Update()
    {
        transform.Rotate(0f, 0f, rotation * Time.deltaTime);
    }

    private IEnumerator MoveUpDown()
    {
        while (true)
        {
            yield return MoveToPoint(pointB);
            yield return new WaitForSeconds(Random.Range(0.5f, 1.5f));
            yield return MoveToPoint(pointA);
            yield return new WaitForSeconds(Random.Range(0.5f, 1.5f));
        }
    }

    private IEnumerator MoveToPoint(Vector3 target)
    {
        while (Vector3.Distance(transform.position, target) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, movementSpeed * Time.deltaTime);
            yield return null;
        }

        transform.position = target;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerLife>().TakeDamage();
        }
    }
}