using UnityEngine;

public class SaveGame : MonoBehaviour
{
    [Header("Player")]
    public GameObject player;
    public Transform spawnPoint;

    [Header("Camera")]
    public Transform cameraPoint;
    public Camera mainCamera;

    private bool hasSaved;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Save();
        }
    }

    public void Save()
    {
        if (!hasSaved)
        {
            Debug.Log(gameObject.name + ": Game Saved");
            SaveManager.instance.SetCheckpoint(this);
            hasSaved = true;
        }
    }

    public void Load()
    {
        player.transform.position = spawnPoint.position;
        mainCamera.transform.position = cameraPoint.position;

        PlayerLife playerLife = player.GetComponent<PlayerLife>();
        playerLife.RestoreAllHealth();

        SoundManager.PlayBackgroundSong();
    }
}
