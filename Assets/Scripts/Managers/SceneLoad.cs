using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject optionsMenu;

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Options()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public  void QuitOptions()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }
}
