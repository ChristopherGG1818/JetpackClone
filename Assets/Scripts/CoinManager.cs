using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance;

    public TMP_Text coinText;
    private int coins = 0;

    void Awake()
    {
        Instance = this;
    }

    public void AddCoin(int amount)
    {
        coins += amount;
        UpdateUI();
    }

    void UpdateUI()
    {
        coinText.text = "Coins: " + coins;
    }
}