using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Holds global variable values for everything in the game
/// used to easily change things in the editor
/// </summary>
public static class GameSettings
{
	#region Fields

	static Setting _settings;
	static PlayerSettings _playerSettings;

	public static GameState CurrentGameState;

	#endregion

	#region Properties

	#region Cubes

	public static int CubeHealth { get => _settings.cubeHealth; }

	public static float CubeBakeTime { get => _settings.cubeBakeTime; }

	public static Color32 ShieldCube { get => _settings.shieldCube; }
	public static Color32 MediumShieldCube { get => _settings.mediumCube; }

	public static Color32 TimeCube { get => _settings.timeCube; }
	public static Color32 DeathCube { get => _settings.deathCube; }
	public static Color32 BakeCube { get => _settings.bakeCube; }
	public static Color32 HealthCube { get => _settings.healthCube; }

	public static List<string> PowerIDs { get => _settings.powerIDs; }

	#endregion

	#region Player

	public static int Health { get => _settings.health; }

	#endregion

	#region Spawner

	public static float SpawnerSpeed { get => _settings.spawnerSpeed; }
	public static int SpawnerMaxAmount { get => _settings.spawnerMaxAmount; }
	public static int SpawnerWeight { get => _settings.spawnerWeight; }

	#endregion

	#region Player Settings

	public static int HighScore { get => _playerSettings.highScore; }
	public static float MusicVolume { get => _playerSettings.music; set => _playerSettings.music = value;  }
	public static float SFXVolume { get => _playerSettings.sfx; set => _playerSettings.sfx = value; }
	public static float TimeScale { get => Mathf.Clamp(_playerSettings.timeScale, 0.3f, 1f); }
	public static int QualityLevel { get =>_playerSettings.quality; set => _playerSettings.quality = value; }

	#endregion

	#endregion

	#region Methods

	public static void Load()
	{
		_settings = Resources.Load("Data/settings") as Setting;
		_playerSettings = PlayerPrefs.GetString("SETTINGS", new PlayerSettings().Pack()).Unpack<PlayerSettings>();

		CurrentGameState = GameState.NoGame;
	}

	public static void Save()
	{
		PlayerPrefs.SetString("SETTINGS", _playerSettings.Pack());
	}

	public static void SetTimeScale(float value)
	{
		_playerSettings.timeScale = value;
	}

	public static void SetHighScore(int value)
	{
		_playerSettings.highScore = value;
	}

	#endregion
}
