using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public PlayerLife playerLife;
    public PlayerCoins playerCoins;

    public void BuyHealing(int amount)
    {
        if (playerLife.CanHeal() && playerCoins.CheckPrice(amount))
        {
            playerLife.Heal();
            playerCoins.RemoveCoins(amount);
        }
    }

    public void BuyBoots(int amount)
    {
        if (playerCoins.CheckPrice(amount))
        {
            playerMovement.AllowRunning();
            playerCoins.RemoveCoins(amount);
        }
    }

    public void BuyStar(int amount)
    {
        if (playerCoins.CheckPrice(amount))
        {

        }
    }
}
