/// <summary>
/// Holds settings the player can change
/// </summary>
[System.Serializable]
public class PlayerSettings
{
	public float music;
	public float sfx;
	public float timeScale;

	public int quality;

	public int highScore;

	public PlayerSettings()
	{
		music = 0;
		sfx = 0;
		timeScale = 1;
		quality = 2;
		highScore = 0;
	}
}