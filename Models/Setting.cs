using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Holds game settings
/// </summary>
[CreateAssetMenu(menuName = "CUBE/Settings Data")]
public class Setting : ScriptableObject
{
	#region Cubes

	[Header("Cubes")]
	public int cubeHealth;

	public float cubeBakeTime;

	public Color32 shieldCube;
	public Color32 mediumCube;
	public Color32 timeCube;
	public Color32 deathCube;
	public Color32 bakeCube;
	public Color32 healthCube;

	public List<string> powerIDs;

	#endregion

	#region Player

	[Header("Player")]
	public int health;

	#endregion

	#region Spawner

	[Header("Spawner")]
	public float spawnerSpeed;
	public int spawnerMaxAmount;
	public int spawnerWeight;

	#endregion
}
