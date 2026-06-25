using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerSpecialAttack : MonoBehaviour
{
    public float cooldown = 90f;

    [Header("Target")]
    public LayerMask target;
    public Vector2 boxSize = new Vector2(50, 50);

    [Header("Ui")]
    public Transform canvas;
    public GameObject textPrefab;
    public Transform spawnPoint;
    public Image starImage;
    public TextMeshProUGUI message;

    private PlayerShoot playerShoot;
    private bool hasStar = false;
    private bool canUseSpecialAttack = false;

    private void Start()
    {
        playerShoot = GetComponent<PlayerShoot>();
    }

    private void OnSpecial(InputValue value)
    {
        if (hasStar && canUseSpecialAttack)
        {
            Collider2D[] hits = Physics2D.OverlapBoxAll(transform.position, boxSize, 0f, target);
            Transform shootPoint = playerShoot.GetShootPoint();

            if (hits.Length > 0)
            {
                foreach (Collider2D hit in hits)
                {
                    Vector2 targetCenter = hit.bounds.center;
                    Vector2 direction = (targetCenter - (Vector2)shootPoint.position).normalized;
                    playerShoot.SpecialShoot(direction);

                    Instantiate(textPrefab, spawnPoint.position, Quaternion.identity, canvas);

                    SoundManager.PlaySound(SoundType.SPECIAL_COWBOY, 2.5f);
                    SoundManager.PlaySound(SoundType.IHAAAA, 0.3f);
                }

                StartCoroutine(AttackCooldown());
            }
            else
            {
                StartCoroutine(ShowMessage());
            }
        }
    }

    public void AllowSpecialAttack()
    {
        starImage.gameObject.SetActive(true);
        hasStar = true;
        canUseSpecialAttack = true;
    }

    private IEnumerator AttackCooldown()
    {
        canUseSpecialAttack = false;
        starImage.color = new Color(starImage.color.r, starImage.color.g, starImage.color.b, 0.5f);
        yield return new WaitForSeconds(cooldown);
        canUseSpecialAttack = true;
        starImage.color = new Color(starImage.color.r, starImage.color.g, starImage.color.b, 1f);
    }

    private IEnumerator ShowMessage()
    {
        message.enabled = true;
        message.text = "There is no enemies around";

        yield return new WaitForSeconds(1.5f);

        message.enabled = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, boxSize);
    }
}
