using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverUI;
    public static GameOverManager instance;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Debug.LogWarning($"Destruction de l'objet en trop : {gameObject.name}");
            Destroy(gameObject); // Supprime cette instance en trop
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public void OnPlayerDeath()
    {
        gameOverUI.SetActive(true);
    }

    public void RetryButton()
    {
        Debug.Log("Appel à RetryButton()");
        if (CurrentSceneManager.instance.isPlayerPresentByDefault)
        {
            DontDestroyOnLoadScene.instance.RemoveFromDontDestroyOnLoad();
        }

        // Réinitialise les Singletons
        Inventory.instance.RemoveCoins(CurrentSceneManager.instance.CoinsPickedUpInThisSceneCount);

        // Recharge la scène
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        // Réinitialise l'état du joueur
        PlayerHealth.instance.Respawn();

        // Désactive l'UI du game over
        gameOverUI.SetActive(false);
    }

    public void MainMenuButton()
    {
        DontDestroyOnLoadScene.instance.RemoveFromDontDestroyOnLoad();
        SceneManager.LoadScene("MainMenu");
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
