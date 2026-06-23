using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public int keyID = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (collision.gameObject.GetComponent<PlayerKeys>().UseKey(keyID))
            {
                Destroy(gameObject);
            }
        }
    }
}
