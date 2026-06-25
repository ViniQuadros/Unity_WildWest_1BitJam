using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Key : MonoBehaviour
{
    public int id = 0;
    public TextMeshProUGUI message;
    public Image keyImage;

    private SpriteRenderer spriteRenderer;
    private bool canCollect = true;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && canCollect)
        {
            canCollect = false;
            SoundManager.PlaySound(SoundType.COLLECT_ITEM);
            collision.GetComponent<PlayerKeys>().AddKey(this);
            StartCoroutine(ShowMessage());
        }
    }

    private IEnumerator ShowMessage()
    {
        spriteRenderer.enabled = false;

        message.enabled = true;
        message.text = "I got the key!";

        keyImage.enabled = true;

        yield return new WaitForSeconds(1.5f);

        message.enabled = false;

        Destroy(gameObject);
    }
}
