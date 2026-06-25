using UnityEngine;

public class IncreaseHeartCount : ItemIncrease
{
    public override void TakeItem(Collider2D collision)
    {
        PlayerLife playerLife = collision.GetComponent<PlayerLife>();
        if (playerLife != null && canCollect)
        {
            text = "Total Life Increased";
            playerLife.IncreaseMaxLife();
            base.TakeItem(collision);
        }
    }
}
