using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OpenDoor : MonoBehaviour
{
    public int keyID = 0;
    public TextMeshProUGUI message;
    public Image keyImage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        StopCoroutine(ShowMessage());
        if (collision.gameObject.tag == "Player")
        {
            if (collision.gameObject.GetComponent<PlayerKeys>().UseKey(keyID))
            {
                SoundManager.PlaySound(SoundType.DOOR_OPENING);
                keyImage.enabled = false;
                Destroy(gameObject);
            }
            else
            {
                StartCoroutine(ShowMessage());
            }
        }
    }

    private IEnumerator ShowMessage()
    {
        message.enabled = true;
        message.text = "I need a key!";
        yield return new WaitForSeconds(1.5f);
        message.enabled = false;
    }
}
