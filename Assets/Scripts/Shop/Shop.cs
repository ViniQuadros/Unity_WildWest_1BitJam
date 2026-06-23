using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject shopPanel;
    public PlayerMovement playerMovement;

    private void Start()
    {
        shopPanel.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            shopPanel.SetActive(true);
            playerMovement.SetCanMove(false);
        }
    }

    public void CloseShop()
    {
        shopPanel.SetActive(false);
        playerMovement.SetCanMove(true);
    }
}
