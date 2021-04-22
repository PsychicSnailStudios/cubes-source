using UnityEngine;

/// <summary>
/// Leaves a little cube behind when it dies
/// </summary>
public class DeathShield : Power
{
    public override void Invoke(string id)
	{
		if (id == Tags.IDs.ShieldCubeEventOnBreak)
		{
			cube.Absorb(1);
			Destroy(cube.gameObject.GetComponent<DeathShield>());

			ShieldCube c = Instantiate(cube, transform.position, Quaternion.identity);
			c.LinkWithGrid(cube.CurrentGrid);
		}
	}
}
