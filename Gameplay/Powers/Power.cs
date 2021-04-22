using UnityEngine;

/// <summary>
/// A special thing that the cube can do 
/// </summary>
public class Power : MonoBehaviour
{
	// The cube that this power is attached to
	protected ShieldCube cube;

	#region Methods

	/// <summary>
	/// Assigns the reference
	/// </summary>
	public void Set(ShieldCube c)
	{
		cube = c;
	}

	/// <summary>
	/// Invokes the Power
	/// </summary>
	public virtual void Invoke(string id)
	{

	}

	#endregion
}
