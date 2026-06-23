using System.Collections;
using UnityEngine;

public class ChangeRoom : MonoBehaviour
{
    [Header("Camera")]
    public Transform cameraTransform;
    public Transform target;
    public float transitionSpeed = 10f;

    [Header("Enemies")]
    public GameObject[] enemies;

    [SerializeField] private BoxCollider2D boxCollider;
    private ChangeRoom startingRoom;
    private bool canGetIn = true;
    private PlayerMovement playerMovement;

    private static ChangeRoom currentRoom;

    private void Start()
    {
        startingRoom = GameObject.FindGameObjectWithTag("StartingRoom").GetComponent<ChangeRoom>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && canGetIn && currentRoom != this)
        {
            playerMovement = collision.GetComponent<PlayerMovement>();
            StartCoroutine(MoveCamera());
        }
    }

    private IEnumerator MoveCamera()
    {
        canGetIn = false;
        playerMovement.SetCanMove(false);

        Vector3 destination = new Vector3(target.position.x, target.position.y, cameraTransform.position.z);

        while (Vector3.Distance(cameraTransform.position, destination) > 0.01f)
        {
            cameraTransform.position = Vector3.MoveTowards(cameraTransform.position, destination, transitionSpeed * Time.deltaTime);
            yield return null;
        }

        foreach (GameObject en in enemies)
        { 
            en.SetActive(true);
        }

        cameraTransform.position = destination;
        currentRoom = this;

        canGetIn = true;
        playerMovement.SetCanMove(true);
    }

    private void OnDrawGizmos()
    {
        if (boxCollider == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawCube(transform.position, new Vector3(boxCollider.size.x, boxCollider.size.y, 0));
    }
}