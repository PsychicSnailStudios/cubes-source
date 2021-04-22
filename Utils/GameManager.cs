using UnityEngine;

/// <summary>
/// Loads game settings
/// </summary>
public class GameManager : MonoBehaviour
{
	private void Awake()
	{
		GameSettings.Load();
	}
}
