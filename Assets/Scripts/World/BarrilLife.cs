using UnityEngine;

public class BarrilLife : Life
{
    public GameObject coin;

    public override void Die()
    {
        SoundManager.PlaySound(SoundType.BREAKING_WALL);
        Instantiate(coin, transform.position, Quaternion.identity);
        base.Die();
    }

}
