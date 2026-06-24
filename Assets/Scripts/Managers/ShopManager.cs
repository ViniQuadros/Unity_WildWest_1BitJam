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
            CompletePurchase(amount);
        }
    }

    public void BuyBoots(int amount)
    {
        if (playerCoins.CheckPrice(amount))
        {
            playerMovement.AllowRunning();
            CompletePurchase(amount);
        }
    }

    public void BuyStar(int amount)
    {
        if (playerCoins.CheckPrice(amount))
        {

        }
    }

    private void CompletePurchase(int amount)
    {
        playerCoins.RemoveCoins(amount);
        SoundManager.PlaySound(SoundType.BUY_ITEM);
    }
}
