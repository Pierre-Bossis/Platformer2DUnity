using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyOnLoadScene : MonoBehaviour
{
    public GameObject[] objects;
    public static DontDestroyOnLoadScene instance;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Debug.LogWarning($"Destruction de l'objet en trop : {gameObject.name}");
            Destroy(gameObject); // Supprime cette instance en trop
            return;
        }
        instance = this;

        foreach (var element in objects)
        {
            DontDestroyOnLoad(element);
        }
    }

    public void RemoveFromDontDestroyOnLoad()
    {
        Debug.Log("Suppression des objets de DontDestroyOnLoad :");
        foreach (var element in objects)
        {
            Debug.Log($"Déplacement de l'objet : {element.name}");
            SceneManager.MoveGameObjectToScene(element, SceneManager.GetActiveScene());
            Destroy(element); // Supprime l'objet après déplacement
        }
    }
}
