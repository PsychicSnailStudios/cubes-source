using System.Collections;
using UnityEngine;

/// <summary>
/// Spawns damage cubes, triggered by the Pipes
/// </summary>
[RequireComponent(typeof(Animator))]
public class Spawner : MonoBehaviour
{
    #region Fields

    public Vector3 spawnOffset;

    Animator _animator;

    int _amount;
    GameObject _cube;
    Transform _anchor;

    #endregion

    #region Unity Methods

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    #endregion

    #region Spawn Methods

    /// <summary>
    /// Gets info about next spawn and starts the animation
    /// </summary>
    public void StartSpawn(GameObject cube, Transform anchor, int amount)
	{
        _cube = cube;
        _anchor = anchor;
        _amount = amount;

        _animator.SetTrigger("Shake");
	}

    /// <summary>
    /// Spawns a bunch of damage cubes
    /// </summary>
    public void Spawn()
    {
        AudioManager.Play(AudioFile.CubeDump, AudioTrack.Block);
        StartCoroutine(Execute(_amount));
    }
    
    IEnumerator Execute(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            yield return new WaitForSeconds(0.1f);
            SpawnCube();
        }
    }

    /// <summary>
    /// Spawns a single damage cube
    /// </summary>
    public void SpawnCube()
    {
        Instantiate(_cube, transform.position + spawnOffset, Quaternion.identity, _anchor);
    }

    #endregion
}
