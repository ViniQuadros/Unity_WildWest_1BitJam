using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;

    public TextMeshProUGUI message;

    private SaveGame saveGame;

    private void Awake()
    {
        SaveManager.instance = this;
    }

    public void SetCheckpoint(SaveGame save)
    {
        StartCoroutine(ShowMessage());
        saveGame = save;
    }

    public void LoadGame()
    {
        if (saveGame == null)
        {
            SceneManager.LoadScene("MainLevel");
        }
        else
        {
            saveGame.Load();
        }
    }

    private IEnumerator ShowMessage()
    {
        SoundManager.PlaySound(SoundType.SAVE);

        message.enabled = true;
        message.text = "Game Saved";

        yield return new WaitForSeconds(1.5f);

        message.enabled = false;
    }
}
