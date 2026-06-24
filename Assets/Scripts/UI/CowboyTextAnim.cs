using System.Collections;
using UnityEngine;

public class CowboyTextAnim : MonoBehaviour
{
    public float speed = 5f;
    public float positionX = -700;

    void Start()
    {
        StartCoroutine(AnimText());
    }

    private IEnumerator AnimText()
    {
        Vector3 target = new Vector3(positionX, transform.position.y);

        while (Vector3.Distance(transform.position, target) > 0.01f)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target, step);
            yield return null;
        }

        transform.position = target;
        yield return new WaitForEndOfFrame();
        Destroy(gameObject);
    }
}
