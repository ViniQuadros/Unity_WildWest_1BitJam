using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{

    public int hearts;
    public int coins;
    public Vector3 position;


    public void getPlayerState()
    {
        hearts = GetComponent<PlayerLife>().maxHealth;
        coins = GetComponent<PlayerCoins>().totalCoins;
        position = transform.position;


    }
}
