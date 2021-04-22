using UnityEngine;

/// <summary>
/// Slows time when moved about
/// </summary>
public class TimeSlow : Power
{
	#region Methods

	void Start()
	{
		EventManager.OnStartGridMove.AddListener(Slow);
		EventManager.OnEndGridMove.AddListener(Return);
	}

	/// <summary>
	/// Slows time
	/// </summary>
	void Slow(int i)
	{
		Time.timeScale = 0.3f * GameSettings.TimeScale;
		EventManager.OnTimeChange.Invoke(false);
	}

	/// <summary>
	/// Brings time back to normal
	/// </summary>
	void Return()
	{
		Time.timeScale = 1 * GameSettings.TimeScale;
		EventManager.OnTimeChange.Invoke(true);
	}

	public override void Invoke(string id)
	{
		if (id == Tags.IDs.ShieldCubeEventOnBreak)
		{
			Return();
		}
	}

	#endregion
}
