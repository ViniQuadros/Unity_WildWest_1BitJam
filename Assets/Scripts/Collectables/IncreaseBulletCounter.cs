using System.Collections;
using TMPro;
using UnityEngine;

public class IncreaseBulletCounter : ItemIncrease
{
    public override void TakeItem(Collider2D collision)
    {
        PlayerShoot playerShoot = collision.GetComponent<PlayerShoot>();
        if (playerShoot != null && canCollect)
        {
            text = "Bullet Amount Increased";
            playerShoot.IncreaseMaxBullets();
            base.TakeItem(collision);
        }
    }
}
