using UnityEngine;
using System;

public enum SoundType
{
    PLAYER_SHOOT,
    ENEMY_SHOOT,
    COLLECT_COIN,
    HURT_PLAYER,
    KILL_CACTUS,
    KILL_PLAYER,
    BUY_ITEM
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
}