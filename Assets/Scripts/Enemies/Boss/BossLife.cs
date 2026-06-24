using UnityEngine;
using UnityEngine.UI;

public class BossLife : Life
{
    public Slider bossLife;

    public override void TakeDamage()
    {
        base.TakeDamage();
        UpdateProgress(5f);
    }

    public void UpdateProgress(float progressPercentage)
    {
        bossLife.value = Mathf.Clamp(progressPercentage, 0f, 1f);
    }
}
