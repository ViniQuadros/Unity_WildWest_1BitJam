using UnityEngine;

public class RoomsManager : MonoBehaviour
{
    private BoxCollider2D collider;
    private ChangeRoom currentRoom;
    [SerializeField] private ChangeRoom startingRoom;

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

    public void SetCurrentRoom(ChangeRoom room)
    {
        currentRoom = room;
    }

    public bool CheckRoom(ChangeRoom room)
    {
        return currentRoom == room;
    }
}
