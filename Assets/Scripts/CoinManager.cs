using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance;

    public TMP_Text coinText;

    public AudioSource coinSound;

    private int coins = 0;

    void Awake()
    {
        Instance = this;
    }

    public void AddCoin(int amount)
    {
        coins += amount;

        // play coin sound
        if (coinSound != null)
            coinSound.Play();

        UpdateUI();
    }

    // spend coins for power-ups / button
    public bool SpendCoins(int amount)
    {
        if (coins >= amount)
        {
            coins -= amount;
            UpdateUI();
            return true;
        }

        return false;
    }

    void UpdateUI()
    {
        if (coinText != null)
            coinText.text = "Coins: " + coins;
    }
}