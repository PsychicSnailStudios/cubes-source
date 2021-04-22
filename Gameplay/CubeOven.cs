using UnityEngine;

/// <summary>
/// Bakes new cubes for the player
/// </summary>
public class CubeOven : MonoBehaviour
{
    #region Fields

    public ShieldCube cubePrefab;
    public GridCube output;
    public Transform anchor;

    float _cooldown;
    float _cookTime;
    bool first = true;

    public float BakeTime { get => _cookTime; }

    #endregion

    #region Unity Methods

    void Start()
    {
        EventManager.OnBoostOvenTime.AddListener(Boost);

        _cooldown = GameSettings.CubeBakeTime;
        _cookTime = GameSettings.CubeBakeTime;
    }

    void Update()
    {
        // increment time
        _cookTime += Time.deltaTime;

        // if the timer finishes and there is room in the output slot
        if (_cookTime >= _cooldown && output.Empty)
        {
            // reset timer
            _cookTime = 0;

            // create new cube
            ShieldCube newCube = Instantiate(cubePrefab, output.Position, Quaternion.identity, anchor);
            newCube.LinkWithGrid(output);

            // don't play sound on level load
			if (!first)
			{
                AudioManager.Play(AudioFile.TimerRing, AudioTrack.SFX);
            }

            // set flag
            first = false;
        }
    }

	#endregion

	#region Methods

    /// <summary>
    /// Adds time to the timer so it will finish sooner
    /// </summary>
    /// <param name="time"></param>
    public void Boost(float time)
	{
        _cookTime += time;
	}

	#endregion
}
