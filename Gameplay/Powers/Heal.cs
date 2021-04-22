/// <summary>
/// Heals you when damaged
/// </summary>
public class Heal : Power
{
    void Start()
    {
		// this one should be weaker for balance
        cube.durability /= 2; 
    }

	public override void Invoke(string id)
	{
		if (id == Tags.IDs.ShieldCubeEventOnDamage)
		{
			EventManager.OnPlayerHeals.Invoke(1);
		}
	}
}
