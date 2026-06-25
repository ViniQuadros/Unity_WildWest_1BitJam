using UnityEngine;

public class RoomsManager : MonoBehaviour
{
    private BoxCollider2D collider;
    private Transform currentRoom;
    [SerializeField] private Transform startingRoom;

    private void Awake()
    {
        collider = GetComponent<BoxCollider2D>();
    }

    private void Start()
    {
        currentRoom = startingRoom;
    }

    public void ActivateBarrier()
    {
        collider.enabled = true;
    }

    public void SetCurrentRoom(Transform room)
    {
        currentRoom = room;
    }

    public bool CheckRoom(Transform room)
    {
        return currentRoom == room;
    }
}
