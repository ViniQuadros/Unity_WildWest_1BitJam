using UnityEngine;

public class SaveGame : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Game Saved");
    }
}
