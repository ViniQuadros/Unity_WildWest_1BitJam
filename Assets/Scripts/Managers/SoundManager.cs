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
    IHAAAA,
    BCKGROUND_MUSIC,
    COLLECT_SPECIAL_ITEM,
    COLLECT_ITEM,
    BREAKING_WALL,
    DOOR_OPENING,
    RELOAD,
    BOSS_MUSIC
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
    private AudioSource sfxSource;
    private AudioSource musicSource;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        musicSource = gameObject.AddComponent<AudioSource>();
        musicSource.loop = true;

        sfxSource = gameObject.AddComponent<AudioSource>();
    }

    private void Start()
    {
        PlayBackgroundSong();
    }

    public static void PlaySound(SoundType sound, float volume = 1f)
    {
        foreach (SoundEntry entry in instance.soundList)
        {
            if (entry.type == sound)
            {
                instance.sfxSource.PlayOneShot(entry.clip, volume);
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

    public static void PlayBackgroundSong()
    {
        foreach (SoundEntry entry in instance.soundList)
        {
            if (entry.type == SoundType.BCKGROUND_MUSIC)
            {
                instance.musicSource.clip = entry.clip;
                instance.musicSource.loop = true;
                instance.musicSource.volume = .2f;
                instance.musicSource.Play();
                return;
            }
        }
    }

    public static void PauseBackgroundSong()
    {
        instance.musicSource.Stop();
    }

    public static void PlayBossSong()
    {
        PauseBackgroundSong();
        foreach (SoundEntry entry in instance.soundList)
        {
            if (entry.type == SoundType.BOSS_MUSIC)
            {
                instance.musicSource.clip = entry.clip;
                instance.musicSource.loop = true;
                instance.musicSource.volume = .2f;
                instance.musicSource.Play();
                return;
            }
        }
    }
}