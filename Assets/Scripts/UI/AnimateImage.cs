using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AnimateImage : MonoBehaviour
{
    public Image image;
    public Sprite[] spriteArray;
    public float waitTime = .1f;

    private int indexSprite;

    private void OnEnable()
    {
        StartCoroutine(Animate());
    }

    private void OnDisable()
    {
        StopCoroutine(Animate());
    }

    private IEnumerator Animate()
    {
        indexSprite = 0;

        while (indexSprite < spriteArray.Length)
        {
            image.sprite = spriteArray[indexSprite];
            indexSprite++;
            yield return new WaitForSeconds(waitTime);
        }

        StartCoroutine(Animate());
    }
}
