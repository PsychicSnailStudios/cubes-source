using UnityEngine;

/// <summary>
/// Handles the random spawning of damage cubes at the top of the level
/// </summary>
public class Pipes : MonoBehaviour
{
    #region Fields

    public GameObject cube;
    public Transform anchor;
    public Spawner[] spawnPoints;

    int _amount;
    int _weight;
    float _cooldown;
    float _time;

    #endregion

    #region Unity Methods

    void Start()
    {
        _cooldown = GameSettings.SpawnerSpeed;
        _amount = GameSettings.SpawnerMaxAmount;
        _weight = GameSettings.SpawnerWeight;
    }

    void Update()
    {
        _time += Time.deltaTime;

		if (_time >= _cooldown)
		{
            _time = 0;

            SetNextWave();
        }
    }

    #endregion

    #region Methods

    /// <summary>
    /// Picks locations for spawning
    /// </summary>
    void SetNextWave()
	{
        spawnPoints.Shuffle();

        int spawnAmount = 1;

        // spawn num is dependent on how full the grid is
        if (LevelManager.GridAmount < spawnPoints.Length - 2)
		{
            spawnAmount = Random.Range(_weight + 1, LevelManager.GridAmount + _weight) - _weight;
        }
		else
		{
            spawnAmount = Random.Range(_weight - 1, LevelManager.GridAmount) + _weight;

            spawnAmount = Mathf.Clamp(spawnAmount, 1, LevelManager.GridAmount);
        }

        // spawn cubes
        for (int i = 0; i < spawnAmount; i++)
		{
            spawnPoints[i].StartSpawn(cube, anchor, _amount);
        }
    }

    #endregion
}
