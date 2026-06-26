using UnityEngine;

public class ChangeBGSong : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SoundManager.PlayBossSong();
    }
}
