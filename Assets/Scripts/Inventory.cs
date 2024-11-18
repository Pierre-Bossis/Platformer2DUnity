using TMPro;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int coinsCount;
    public TextMeshProUGUI coinsCountUI;

    public static Inventory instance;

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

    public void AddCoins(int count)
    {
        coinsCount += count;
        coinsCountUI.text = coinsCount.ToString();
    }

    public void RemoveCoins(int count)
    {
        coinsCount -= count;
        coinsCountUI.text = coinsCount.ToString();
    }
}
