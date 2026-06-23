using System.Collections;
using TMPro;
using UnityEngine;

public class IncreaseBulletCounter : MonoBehaviour
{
    public TextMeshProUGUI message;

    private SpriteRenderer spriteRenderer;
    private bool canCollect = true;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerShoot playerShoot = collision.GetComponent<PlayerShoot>();
            if (playerShoot != null && canCollect)
            {
                playerShoot.IncreaseMaxBullets();
                canCollect = false;
                StartCoroutine(ShowMessage());
            }
        }
    }

    private IEnumerator ShowMessage()
    {
        spriteRenderer.enabled = false;
        message.enabled = true;
        message.text = "Bullet amount increased";

        yield return new WaitForSeconds(1.5f);

        message.enabled = false;
        Destroy(gameObject);
    }
}
