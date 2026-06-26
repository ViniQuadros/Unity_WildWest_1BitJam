using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        float volume = 0.5f;
        if (collision.CompareTag("Player"))
        {
            SoundManager.PlaySound(SoundType.COLLECT_COIN, volume);
            collision.GetComponent<PlayerCoins>().IncreaseCoins();
            Destroy(gameObject);
        }
    }
}
