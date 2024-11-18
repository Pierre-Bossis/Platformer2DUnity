using Unity.VisualScripting;
using UnityEngine;

public class CurrentSceneManager : MonoBehaviour
{
    public bool isPlayerPresentByDefault = false;
    public int CoinsPickedUpInThisSceneCount;

    public static CurrentSceneManager instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Debug.LogWarning($"Destruction de l'objet en trop : {gameObject.name}");
            Destroy(gameObject);
            return;
        }
        instance = this;
    }
}
