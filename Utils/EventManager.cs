using UnityEngine.Events;

/// <summary>
/// Handles the games events
/// </summary>
public static class EventManager
{
	#region Player

	public static UnityEvent<int> OnPlayerTakesDamage = new UnityEvent<int>();
	public static UnityEvent<int> OnPlayerBlocksDamage = new UnityEvent<int>();
	public static UnityEvent<int> OnPlayerHeals = new UnityEvent<int>();

	public static UnityEvent OnPlayerDies = new UnityEvent();

	public static UnityEvent<bool> OnTimeChange = new UnityEvent<bool>();

	#endregion

	#region Grid

	public static UnityEvent<int> OnStartGridMove = new UnityEvent<int>();
	public static UnityEvent OnEndGridMove = new UnityEvent();

	#endregion

	#region Oven

	public static UnityEvent<float> OnBoostOvenTime = new UnityEvent<float>();

	#endregion
}
