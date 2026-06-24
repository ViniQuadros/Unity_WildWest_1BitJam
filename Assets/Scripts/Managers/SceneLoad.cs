using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoad : MonoBehaviour
{
    public CanvasGroup fadeImage;

    [Header("Panels")]
    public GameObject mainMenu;
    public GameObject optionsMenu;

    [Header("Audio")]
    public AudioClip button;
    public AudioClip gunShot;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Play()
    {
        StartCoroutine(StartGame());
    }

    public void Quit()
    {
        audioSource.PlayOneShot(button);
        Application.Quit();
    }

    public void Options()
    {
        audioSource.PlayOneShot(button);
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public  void QuitOptions()
    {
        audioSource.PlayOneShot(button);
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }

    private IEnumerator StartGame()
    {
        audioSource.PlayOneShot(gunShot);
        yield return StartCoroutine(FadeIn(gunShot.length + 1f));
        yield return new WaitForSeconds(gunShot.length);
        SceneManager.LoadScene("MainLevel");
    }

    private IEnumerator FadeIn(float fadeSpeed)
    {
        fadeImage.gameObject.SetActive(true);
        fadeImage.alpha = 0f;

        while (fadeImage.alpha < 1f)
        {
            fadeImage.alpha += Time.deltaTime * fadeSpeed;
            yield return null;
        }

        fadeImage.alpha = 1f;
    }
}
