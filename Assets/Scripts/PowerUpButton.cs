using UnityEngine;

public class PowerUpButton : MonoBehaviour
{
    public int cost = 10;
    public PlayerBehavior player;

    public void UsePowerUp()
    {
        if (CoinManager.Instance.SpendCoins(cost))
        {
            player.ActivateInvisibility();
        }
    }
}