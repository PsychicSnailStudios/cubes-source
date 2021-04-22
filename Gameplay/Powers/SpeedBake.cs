/// <summary>
/// Speeds up bake time when damaged
/// </summary>
public class SpeedBake : Power
{
	#region Fields

	int count;

	int points = 10;

	#endregion

	#region Methods

	public override void Invoke(string id)
	{
		switch (id)
		{
			case Tags.IDs.ShieldCubeEventOnDamage:
				Add();
				break;

			case Tags.IDs.ShieldCubeEventOnBreak:
				End();
				break;
		}
	}

	/// <summary>
	/// finishes the oven every x damage taken
	/// </summary>
	void Add()
	{
		count++;

		if (count >= points)
		{
			count = 0;
			EventManager.OnBoostOvenTime.Invoke(GameSettings.CubeBakeTime);
		}
	}

	/// <summary>
	/// If the cube is destroyed give a little extra boost if you were already close
	/// </summary>
	void End()
	{
		if (count > points / 2)
		{
			EventManager.OnBoostOvenTime.Invoke(GameSettings.CubeBakeTime);
		}
	}

	#endregion
}
