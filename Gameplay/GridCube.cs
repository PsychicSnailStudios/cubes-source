using UnityEngine;

/// <summary>
/// A grid cell, holds Shield Cubes
/// </summary>
public class GridCube : MonoBehaviour
{
	#region Properties

	/// <summary>
	/// Whether or not there is something in the grid
	/// </summary>
	public bool Empty
	{
		get { if (Cube == null) return true; return false; }
	}

	/// <summary>
	/// The grids position
	/// </summary>
	public Vector3 Position { get => transform.position.TrimZ(); }

	/// <summary>
	/// The cube that is currently being held
	/// </summary>
	public ShieldCube Cube { get => _cube; set => _cube = value; }

	/// <summary>
	/// Whether or not the grid is locked
	/// </summary>
	public bool Locked { get => _locked; }

	#endregion

	#region Fields

	[SerializeField] bool _locked = false;

	Vector3 _origin;

	ShieldCube _cube;
	SpriteRenderer _sprite;

	#endregion

	#region Unity Methods

	private void Awake()
	{
		_origin = transform.position;

		_sprite = GetComponent<SpriteRenderer>();

		EventManager.OnStartGridMove.AddListener(Show);
		EventManager.OnEndGridMove.AddListener(Hide);
	}

	#endregion

	#region Event Methods

	void Show(int value)
	{
		_sprite.enabled = true;
		Scale(value);
	}

	void Hide()
	{
		_sprite.enabled = false;
		Rescale();
	}

	#endregion

	#region Methods

	/// <summary>
	/// Rescales to fit the contents
	/// </summary>
	public void Rescale(bool ignoreFullSlot = false)
	{
		if (!_locked)
		{
			if (Empty || ignoreFullSlot)
			{
				transform.localScale = new Vector3(1, 1, 1);
				transform.position = _origin;
			}

			if (!Empty && !ignoreFullSlot)
			{
				transform.position = _origin;
				Scale(_cube.Level, true);
			}
		}
	}

	/// <summary>
	/// Updates its scale
	/// </summary>
	public void Scale(int scale, bool ignoreFullSlot = false)
	{
		if (!_locked)
		{
			if (Empty || ignoreFullSlot)
			{
				transform.localScale = new Vector3(1, scale, 1);
				transform.position = _origin + new Vector3(0, 0.5f * (scale - 1), 0);
			}
		}
	}

	#endregion
}
