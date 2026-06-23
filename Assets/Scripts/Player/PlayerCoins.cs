using TMPro;
using UnityEngine;

public class PlayerCoins : MonoBehaviour
{
    public TextMeshProUGUI coinsTxt;

    private int totalCoins = 0;

    void Start()
    {
        coinsTxt.text = totalCoins.ToString();
    }

    public void IncreaseCoins()
    {
        totalCoins++;
        coinsTxt.text = totalCoins.ToString();
    }

    public void CheckPrice(int price)
    {
        if (totalCoins >= price)
        {
            RemoveCoins(price);
        }
    }

    public void RemoveCoins(int amount)
    {
        totalCoins -= amount;
        coinsTxt.text = totalCoins.ToString();
    }
}
