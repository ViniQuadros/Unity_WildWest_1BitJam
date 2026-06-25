using System.Collections;
using TMPro;
using UnityEngine;

public class ItemIncrease : MonoBehaviour
{
    public TextMeshProUGUI message;
    public string text;

    private SpriteRenderer spriteRenderer;
    protected bool canCollect = true;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public virtual void TakeItem(Collider2D collision)
    {
        SoundManager.PlaySound(SoundType.COLLECT_SPECIAL_ITEM);
        StartCoroutine(ShowMessage());
        canCollect = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            TakeItem(collision);
        }
    }

    private IEnumerator ShowMessage()
    {
        spriteRenderer.enabled = false;
        message.enabled = true;
        message.text = text;

        yield return new WaitForSeconds(1.5f);

        message.enabled = false;
        Destroy(gameObject);
    }
}
