using TMPro;
using UnityEngine;

public class PlayerCoins : MonoBehaviour
{
    public TextMeshProUGUI[] coinsTxt;

    public int totalCoins = 0;

    void Start()
    {
        foreach (var coin in coinsTxt)
        {
            coin.text = totalCoins.ToString();
        }
    }

    public void IncreaseCoins()
    {
        totalCoins++;
        foreach (var coin in coinsTxt)
        {
            coin.text = totalCoins.ToString();
        }
    }

    public bool CheckPrice(int price)
    {
        return totalCoins >= price;
    }

    public void RemoveCoins(int amount)
    {
        totalCoins -= amount;
        foreach (var coin in coinsTxt)
        {
            coin.text = totalCoins.ToString();
        }
    }
}
