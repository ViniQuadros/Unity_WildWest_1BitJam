using System;
using UnityEngine;
using UnityEngine.Rendering;

public enum SoundType
{
    PLAYER_SHOOT,
    ENEMY_SHOOT,
    COLLECT_COIN,
    HURT_PLAYER,
    KILL_CACTUS,
    KILL_PLAYER,
    BUY_ITEM,
    SPECIAL_COWBOY,
    IHAAAA
}

[Serializable]
public struct SoundEntry
{
    public SoundType type;
    public AudioClip clip;
}

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    [SerializeField] private SoundEntry[] soundList;

    private static SoundManager instance;
    private AudioSource audioSource;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
        audioSource = GetComponent<AudioSource>();
    }

    public static void PlaySound(SoundType sound, float volume = 1f)
    {
        foreach (SoundEntry entry in instance.soundList)
        {
            if (entry.type == sound)
            {
                instance.audioSource.PlayOneShot(entry.clip, volume);
                return;
            }
        }
    }

    public static float GetSoundLength(SoundType sound)
    {
        foreach (SoundEntry entry in instance.soundList)
        {
            if (entry.type == sound)
            {
                return entry.clip.length;
            }
        }

        return 1f;
    }
}