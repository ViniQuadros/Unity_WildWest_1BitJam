using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Hearts : MonoBehaviour
{
    public Image image;
    public Sprite[] spriteArrayLose;
    public Sprite[] spriteArrayGain;
    public float waitTime = .1f;

    private int indexSprite;

    public void GainHeart()
    {
        indexSprite = 0;
        StartCoroutine(PlayImageAnim(spriteArrayGain));
    }

    public void LoseHeart()
    {
        indexSprite = 0;
        StartCoroutine(PlayImageAnim(spriteArrayLose));
    }

    public void GetNewHeart()
    {
        image.enabled = true;
        GainHeart();
    }

    private IEnumerator PlayImageAnim(Sprite[] sprites)
    {
        while (indexSprite < sprites.Length)
        {
            image.sprite = sprites[indexSprite];
            indexSprite++;
            yield return new WaitForSeconds(waitTime);
        }
    }
}