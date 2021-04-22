using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

/// <summary>
/// The audio source for the entire game
/// V0.3, replace with V1.0 if this ever leaves game jam edition
/// </summary>
[RequireComponent(typeof(AudioSource))]
public class AudioSourceManager : MonoBehaviour
{
    #region Fields

    // assign in inspector

    // snapshots
    public AudioMixerSnapshot normal;
    public AudioMixerSnapshot lowpass;

    // tracks
    public AudioMixerGroup music;
    public AudioMixerGroup master;
    public AudioMixerGroup sfx;
    public AudioMixerGroup block;
    public AudioMixerGroup ui;

    // main music source
    public AudioSource song;

    #endregion

    #region Unity Methods

    /// <summary>
    /// Awake is called before Start
    /// </summary>
    void Awake()
    {
        EventManager.OnTimeChange.AddListener(TimeScale);

        // initialize audio manager
        if (AudioManager.IsInitialised)
        {
            // if there is already an audio source then destroy this one
            Destroy(gameObject);
        }
        else
        {
            // create the audio sources
            Dictionary<AudioTrack, AudioSource> audioSources = new Dictionary<AudioTrack, AudioSource>();

            foreach (AudioTrack track in Enum.GetValues(typeof(AudioTrack)))
            {
                switch (track)
                {
                    case AudioTrack.SFX:
                        AudioSource source = gameObject.AddComponent<AudioSource>();
                        source.outputAudioMixerGroup = sfx;
                        audioSources.Add(AudioTrack.SFX, source);
                        break;

                    case AudioTrack.Music:
                        AudioSource source2 = gameObject.AddComponent<AudioSource>();
                        source2.outputAudioMixerGroup = music;
                        audioSources.Add(AudioTrack.Music, source2);
                        break;

                    case AudioTrack.Block:
                        AudioSource source4 = gameObject.AddComponent<AudioSource>();
                        source4.outputAudioMixerGroup = block;
                        audioSources.Add(AudioTrack.Block, source4);
                        break;

                    case AudioTrack.UI:
                        AudioSource source5 = gameObject.AddComponent<AudioSource>();
                        source5.outputAudioMixerGroup = ui;
                        audioSources.Add(AudioTrack.UI, source5);
                        break;

                    default:
                        AudioSource source3 = gameObject.AddComponent<AudioSource>();
                        source3.outputAudioMixerGroup = master;
                        audioSources.Add(AudioTrack.Master, source3);
                        break;
                }
            }

            // initialize the sources with the audio manager
            AudioManager.Initialize(audioSources);
            // make sure this persists between scenes
            DontDestroyOnLoad(gameObject);
        }
    }

    #endregion

    #region Methods

    /// <summary>
    /// Transitions between having a lowpass filter and speed effects on or off
    /// </summary>
    /// <param name="isNormal">set to true to turn lowpass off</param>
    void TimeScale(bool isNormal)
    {
        if (isNormal)
        {
            normal.TransitionTo(0f);

            song.pitch = 1;
            AudioManager.SetPitch(1, AudioTrack.Block);
            AudioManager.SetPitch(1, AudioTrack.SFX);
            AudioManager.SetPitch(1, AudioTrack.Music);
            AudioManager.SetPitch(1, AudioTrack.Master);
        }
        else
        {
            lowpass.TransitionTo(0f);
            song.pitch = Time.timeScale * 2.7f;
            song.pitch = Mathf.Clamp(song.pitch, 0.42f, 0.99f);
            AudioManager.SetPitch(Time.timeScale, AudioTrack.Block);
            AudioManager.SetPitch(Time.timeScale, AudioTrack.SFX);
            AudioManager.SetPitch(Time.timeScale, AudioTrack.Music);
            AudioManager.SetPitch(Time.timeScale, AudioTrack.Master);
        }
    }

    #endregion
}