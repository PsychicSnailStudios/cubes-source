using System;
using UnityEngine;

/// <summary>
/// Player uses these to block damage cubes
/// </summary>
public class ShieldCube : MonoBehaviour
{
	#region Fields

	[SerializeField] public float _highlightedScale;
	[SerializeField] public float _pressedScale;
	[SerializeField] public float _selectedScale;

	[Tooltip("How long it takes to scale up or down.")]
	[SerializeField] public float _scaleTime;

	Vector3 _realScale;

	public ParticleSystem particals;

	public int durability { get; set; }

	int _damageTaken = 0;
	int _level = 1;

	// drag & drop
	Vector3 _dragOffset;
	Vector3 _firstPos;
	bool _locked = false;

	// refs
	Collider2D _col;
	SpriteRenderer _sprite;
	Power _power;

	GridCube _currentGrid;

	#endregion

	#region Properties

	/// <summary>
	///  The grid the cube is in
	/// </summary>
	public GridCube CurrentGrid { get => _currentGrid; set => _currentGrid = value; }

	/// <summary>
	/// The power level of the cube
	/// </summary>
	public int Level { get => _level; }

	Vector3 Offset => new Vector3(0, 0.5f * (_level - 1), 0);

	#endregion

	#region Unity Methods

	void Start()
    {
		_col = GetComponent<Collider2D>();
		_sprite = GetComponent<SpriteRenderer>();

		_firstPos = transform.position;
		_realScale = transform.localScale;

		durability = GameSettings.CubeHealth;
		_sprite.color = GameSettings.ShieldCube;
    }

    void Update()
    {
		if (!_locked)
		{
			
		}
    }

	#endregion

	#region Methods

	/// <summary>
	/// Removes the cube from the game
	/// </summary>
	public void DestroyCube()
	{
		// invoke power
		if (_power != null)
		{
			_power.Invoke(Tags.IDs.ShieldCubeEventOnBreak);
		}

		// particles
		ParticleSystem p = Instantiate(particals, transform.position, transform.rotation);
		ParticleSystem.ShapeModule shape = p.shape;
		shape.scale = transform.localScale;
		ParticleSystem.EmissionModule e = p.emission;
		e.burstCount = Level * 100;

		// sound
		AudioManager.Play(AudioFile.CubeDie, AudioTrack.SFX);

		// remove
		Destroy(gameObject);
	}

	/// <summary>
	/// Damages the cube
	/// </summary>
	public void Damage(int damage)
	{
		// damage
		_damageTaken += damage;

		// dynamic coloring
		Color32 c = _sprite.color;

		float percent = ((float)_damageTaken / durability) * 255;
		int alpha = 255 - Mathf.Clamp(Mathf.RoundToInt(percent), 0, 255);
		
		c.a = Convert.ToByte(alpha);

		_sprite.color = c;

		// invoke power
		if (_power != null)
		{
			_power.Invoke(Tags.IDs.ShieldCubeEventOnDamage);
		}

		// destroy if out of durability
		if (_damageTaken > durability)
		{
			DestroyCube();
		}
	}

	/// <summary>
	/// Heals the cube to full
	/// </summary>
	public void Refresh()
	{
		_damageTaken = 0;
	}

	/// <summary>
	/// Levels up the cube
	/// </summary>
	public void Absorb(int newLevel)
	{
		_level = newLevel;
		durability =  GameSettings.CubeHealth * _level;

		CurrentGrid.Scale(_level, true);
		transform.localScale = new Vector3(1, _level, 1);
		transform.position = CurrentGrid.Position;
		_realScale = transform.localScale;
		_firstPos = CurrentGrid.Position;

		LevelUpEffect();
	}

	/// <summary>
	/// Controls what happens when the cube levels up
	/// </summary>
	void LevelUpEffect()
	{
		Refresh();

		switch (_level)
		{
			case 2:
				_sprite.color = GameSettings.MediumShieldCube;
				break;

			case 3:
				AddRandomPower();
				break;
		}
	}

	/// <summary>
	/// Gives the cube a random power
	/// </summary>
	void AddRandomPower()
	{
		string id = GameSettings.PowerIDs.GetRandom();

		switch (id)
		{
			case Tags.IDs.TimePower:
				_power = gameObject.AddComponent<TimeSlow>();
				_sprite.color = GameSettings.TimeCube;
				break;

			case Tags.IDs.DeathPower:
				_power = gameObject.AddComponent<DeathShield>();
				_sprite.color = GameSettings.DeathCube;
				break;

			case Tags.IDs.HealthPower:
				_power = gameObject.AddComponent<Heal>();
				_sprite.color = GameSettings.HealthCube;
				break;

			case Tags.IDs.BakePower:
				_power = gameObject.AddComponent<SpeedBake>();
				_sprite.color = GameSettings.BakeCube;
				break;

			default:
				break;
		}

		_power.Set(this);
	}
	
	#endregion

	#region Grid Methods

	/// <summary>
	/// Links this with a new grid cell
	/// </summary>
	public void LinkWithGrid(GridCube cube)
	{
		UnlinkFromGrid();
		_currentGrid = cube;
		_currentGrid.Cube = this;
	}

	/// <summary>
	/// Unlinks this with its grid cell
	/// </summary>
	void UnlinkFromGrid()
	{
		if (_currentGrid != null)
		{
			_currentGrid.Cube = null;
		}
	}

	#region Events

	private void OnMouseEnter()
	{
		LeanTween.scale(gameObject, _realScale * _highlightedScale, _scaleTime).setIgnoreTimeScale(true);
		_sprite.sortingOrder = 1;
	}

	private void OnMouseExit()
	{
		LeanTween.scale(gameObject, _realScale, _scaleTime).setIgnoreTimeScale(true);
		_sprite.sortingOrder = 0;
	}

	private void OnMouseDown()
	{
		if (!_locked)
		{
			_locked = true;
			StartDrag();
		}

		LeanTween.scale(gameObject, _realScale * _selectedScale, _scaleTime).setIgnoreTimeScale(true);
	}

	private void OnMouseDrag()
	{
		if (_locked)
		{
			Drag();
		}
	}

	private void OnMouseUp()
	{
		if (_locked)
		{
			EndDrag();
		}
		_locked = false;
	}

	#endregion

	#region Drag and Drop

	void StartDrag()
	{
		EventManager.OnStartGridMove.Invoke(_level);
		_col.enabled = false;
		AudioManager.Play(AudioFile.CubeDrag, AudioTrack.UI);

		// drag calculations
		_firstPos = transform.position;

		_dragOffset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
	}

	void Drag()
	{
		// drag calculations
		transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0)) + _dragOffset;
	}

	void EndDrag()
	{
		// get all the colliders
		Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, transform.localScale, 0f);
		// drag calculations
		GridCube nearestCube = null;
		Vector3 nearestPos = _firstPos.TrimZ();
		Vector3 currentPos = transform.position.TrimZ();
		// snap to the nearest valid point
		foreach (var item in colliders)
		{
			if (item.tag == Tags.Grid && Vector3.Distance(currentPos, item.transform.position.TrimZ()) < Vector3.Distance(currentPos, nearestPos))
			{
				GridCube cube = item.GetComponent<GridCube>();
				nearestCube = cube;
				nearestPos = cube.Position;
			}
		}

		// link to new grid and unlink from old one
		if (nearestCube == null)
		{
			nearestPos = _firstPos;
		}
		else
		{
			if (nearestCube.Empty)
			{
				LinkWithGrid(nearestCube);
			}
			else
			{
				// the slot is already full
				if (nearestCube.Cube.Level + _level <= 3)
				{
					if (nearestCube.Cube != this)
					{
						UnlinkFromGrid();
						nearestCube.Cube.Absorb(nearestCube.Cube.Level + _level);
						Destroy(gameObject);
						//DestroyCube();
					}
				}
				else
				{
					nearestPos = _firstPos;
				}
			}
		}

		_firstPos = nearestPos;

		transform.position = nearestPos;

		OnDragFinished();
	}

	void OnDragFinished()
	{
		EventManager.OnEndGridMove.Invoke();
		_col.enabled = true;
		AudioManager.Play(AudioFile.CubeDrop, AudioTrack.UI);
	}

	#endregion

	#endregion
}
