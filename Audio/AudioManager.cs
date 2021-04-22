using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles the games audio
/// V0.3, replace with V1.0 if this ever leaves game jam edition
/// </summary>
public static class AudioManager
{
    #region Feilds

    // singleton support
    static bool isInitialised = false;

    // audio sources to play from
    static AudioSource masterAudioSource;
    static AudioSource effectsAudioSource;
    static AudioSource musicAudioSource;
    static AudioSource blockAudioSource;
    static AudioSource uiAudioSource;

    // the audio files in the game
    static Dictionary<AudioFile, AudioClip> audioClips = new Dictionary<AudioFile, AudioClip>();

    #endregion

    #region Properties

    /// <summary>
    /// Weather or not the audio source has already been initialized
    /// </summary>
    public static bool IsInitialised
    {
        get { return isInitialised; }
        set { isInitialised = value; }
    }

    #endregion

    #region Methods

    /// <summary>
    /// Initializes the audio manager
    /// </summary>
    /// <param name="sources">the audio sources to use</param>
    public static void Initialize(Dictionary<AudioTrack, AudioSource> sources)
    {
        // set the sources
        foreach (KeyValuePair<AudioTrack, AudioSource> entry in sources)
        {
            // run through the dictionary and set the sources approperatly
            switch (entry.Key)
            {
                case AudioTrack.Master:
                    masterAudioSource = entry.Value;
                    break;
                case AudioTrack.SFX:
                    effectsAudioSource = entry.Value;
                    break;
                case AudioTrack.Music:
                    musicAudioSource = entry.Value;
                    break;
                case AudioTrack.Block:
                    blockAudioSource = entry.Value;
                    break;
                case AudioTrack.UI:
                    uiAudioSource = entry.Value;
                    break;
                default:
                    // default to master
                    masterAudioSource = entry.Value;
                    break;
            }
        }

        // make sure the list is clear
        audioClips.Clear();

        // --> add clips <--
        audioClips.Add(AudioFile.Music, Resources.Load("Sound/falling_cubes") as AudioClip);
        audioClips.Add(AudioFile.TimerRing, Resources.Load("Sound/SFX/oven_finish") as AudioClip);
        audioClips.Add(AudioFile.CubeDrop, Resources.Load("Sound/SFX/squishy_drop") as AudioClip);
        audioClips.Add(AudioFile.CubeDrag, Resources.Load("Sound/SFX/squishy_drag") as AudioClip);
        audioClips.Add(AudioFile.CubeDump, Resources.Load("Sound/SFX/poor_cubes") as AudioClip);
        audioClips.Add(AudioFile.Shatter, Resources.Load("Sound/SFX/cube_shatter") as AudioClip);
        audioClips.Add(AudioFile.CubeDie, Resources.Load("Sound/SFX/pop") as AudioClip);

        // set the initialization flag
        isInitialised = true;
    }

    /// <summary>
    /// Plays the given audio clip
    /// </summary>
    /// <param name="name">name of the audio clip to play</param>
    /// <param name="track">the track to play in</param>
    public static void Play(AudioFile name, AudioTrack track)
    {
        // play in approprate track
        switch (track)
        {
            case AudioTrack.Master:
                masterAudioSource.PlayOneShot(audioClips[name]);
                break;
            case AudioTrack.SFX:
                effectsAudioSource.PlayOneShot(audioClips[name]);
                break;
            case AudioTrack.Music:
                musicAudioSource.PlayOneShot(audioClips[name]);
                break;
            case AudioTrack.Block:
                blockAudioSource.PlayOneShot(audioClips[name]);
                break;
            case AudioTrack.UI:
                uiAudioSource.PlayOneShot(audioClips[name]);
                break;
            default:
                // default to master
                masterAudioSource.PlayOneShot(audioClips[name]);
                break;
        }
    }
    public static void Play(AudioClip clip, AudioTrack track)
    {
        // play in approprate track
        switch (track)
        {
            case AudioTrack.Master:
                masterAudioSource.PlayOneShot(clip);
                break;
            case AudioTrack.SFX:
                effectsAudioSource.PlayOneShot(clip);
                break;
            case AudioTrack.Music:
                musicAudioSource.PlayOneShot(clip);
                break;
            case AudioTrack.Block:
                blockAudioSource.PlayOneShot(clip);
                break;
            case AudioTrack.UI:
                uiAudioSource.PlayOneShot(clip);
                break;
            default:
                // default to master
                masterAudioSource.PlayOneShot(clip);
                break;
        }
    }

    /// <summary>
    /// Sets the pitch of the source
    /// </summary>
    /// <param name="pitch">the new pitch to play at</param>
    /// <param name="track">the track to edit</param>
    public static void SetPitch(float pitch, AudioTrack track)
    {
        // edit the approprate track
        switch (track)
        {
            case AudioTrack.Master:
                masterAudioSource.pitch = pitch;
                break;
            case AudioTrack.SFX:
                effectsAudioSource.pitch = pitch;
                break;
            case AudioTrack.Music:
                musicAudioSource.pitch = pitch;
                break;
            case AudioTrack.Block:
                blockAudioSource.pitch = pitch;
                break;
            case AudioTrack.UI:
                uiAudioSource.pitch = pitch;
                break;
            default:
                // default to master
                masterAudioSource.pitch = pitch;
                break;
        }
    }

    /// <summary>
    /// Sets the volume of the source
    /// </summary>
    /// <param name="volume">the new volume to play at</param>
    /// <param name="track">the track edit</param>
    public static void SetVolume(float volume, AudioTrack track)
    {
        // edit the approprate track
        switch (track)
        {
            case AudioTrack.Master:
                masterAudioSource.volume = volume;
                break;
            case AudioTrack.SFX:
                effectsAudioSource.volume = volume;
                break;
            case AudioTrack.Music:
                musicAudioSource.volume = volume;
                break;
            default:
                // default to master
                masterAudioSource.volume = volume;
                break;
        }
    }

    #endregion
}