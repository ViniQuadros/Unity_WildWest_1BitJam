using UnityEngine;

public class Key : MonoBehaviour
{
    public int id = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SoundManager.PlaySound(SoundType.COLLECT_ITEM);
            collision.GetComponent<PlayerKeys>().AddKey(this);
            Destroy(gameObject);
        }
    }
}
