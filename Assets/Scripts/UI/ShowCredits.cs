using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShowCredits : MonoBehaviour
{
    public RectTransform panel;
    public Vector2 targetPosition;
    public float duration = 10f;

    private void Start()
    {
        StartCoroutine(MoveToPosition());
    }

    private IEnumerator MoveToPosition()
    {
        Vector2 startPosition = panel.anchoredPosition;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / duration;
            panel.anchoredPosition = Vector2.Lerp(startPosition, targetPosition, t);
            yield return null;
        }

        panel.anchoredPosition = targetPosition;
        SceneManager.LoadScene("MainMenu");
    }
}