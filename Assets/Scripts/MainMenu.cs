using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string levelToLoad;
    public GameObject settingsWindow;
    public void StartGame()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && settingsWindow.activeSelf)
        {
            settingsWindow.SetActive(false);
        }
    }

    public void SettingsButton()
    {
        settingsWindow.SetActive(true);
    }

    public void CloseSettingsWindow()
    {
        settingsWindow.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadCredits()
    {
        SceneManager.LoadScene("Credits");
    }
}
