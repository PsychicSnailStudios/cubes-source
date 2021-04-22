using System;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

/// <summary>
/// Handles the settings menu and updating its ui and the games settings
/// </summary>
public class SettingsMenu : MonoBehaviour
{
    #region Fields

    public AudioMixer mixer;

    public Slider musicSlider;
    public Slider sfxSlider;
    public TMP_Text timeText;
    public Slider timeSlider;
    public TMP_Dropdown qualityDropdown;

    bool _loadedSettings = false;

    #endregion

    #region Unity Methods

    void OnEnable()
    {
        LoadSettings();

        if (!_loadedSettings)
        {
            _loadedSettings = true;
            if (GameSettings.CurrentGameState != GameState.Paused)
            {
                Close();
            }
        }
    }

    #endregion

    #region Update Methods

    public void UpdateMusic(float value)
    {
        mixer.SetFloat("MUSIC", value);
        GameSettings.MusicVolume = value;
    }

    public void UpdateSFX(float value)
    {
        mixer.SetFloat("SFX", value);
        GameSettings.SFXVolume = value;
    }

    public void UpdateTime(float value)
    {
        GameSettings.SetTimeScale(value);
        timeText.text = $"TIME SCALE: {Math.Round(value, 1)}x";
    }

    public void UpdateQuality(int value)
    {
        GameSettings.QualityLevel = value;
        QualitySettings.SetQualityLevel(value);
    }

    #endregion

    #region Methods

    public void ResetScore()
    {
        GameSettings.SetHighScore(0);
    }

    public void Close()
    {
        GameSettings.Save();

        gameObject.SetActive(false);
    }

    /// <summary>
    /// Loads the settings and updates the ui
    /// </summary>
    public void LoadSettings()
    {
        UpdateMusic(GameSettings.MusicVolume);
        musicSlider.value = GameSettings.MusicVolume;

        UpdateSFX(GameSettings.SFXVolume);
        sfxSlider.value = GameSettings.SFXVolume;

        UpdateTime(GameSettings.TimeScale);
        timeSlider.value = GameSettings.TimeScale;

        UpdateQuality(GameSettings.QualityLevel);
        qualityDropdown.value = GameSettings.QualityLevel;
    }

    #endregion
}
