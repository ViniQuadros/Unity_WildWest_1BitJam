using UnityEngine;
using UnityEngine.Audio;

public class MixerManager : MonoBehaviour
{
    public static MixerManager instance;
    [SerializeField] private AudioMixer myAudioMixer;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SetVolume(float sliderValue)
    {
        float clampedValue = Mathf.Max(sliderValue, 0.0001f);
        myAudioMixer.SetFloat("MasterVolume", Mathf.Log10(clampedValue) * 20);
    }
}