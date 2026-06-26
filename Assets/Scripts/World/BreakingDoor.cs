using UnityEngine;

public class BreakingDoor : Life
{
    public override void Die()
    {

        SoundManager.PlaySound(SoundType.KILL_CACTUS);
        base.Die();
      
    }

}
