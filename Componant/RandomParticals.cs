using UnityEngine;

/// <summary>
/// makes the particle system randomly spit out particles
/// </summary>
[RequireComponent(typeof(ParticleSystem))]
public class RandomParticals : MonoBehaviour
{
	#region Fields

	[Tooltip("how often to try and spawn particles.")]
    public float interval = 5f;
    [Tooltip("The chance of one spawning")]
    public Vector2 chance = new Vector2(1, 10);

    float time;
    ParticleSystem _particals;

    #endregion

    #region Methods

    void Start()
    {
        _particals = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        // increment time
        time += Time.deltaTime;

        if (time >= interval)
        {
            if (Random.Range(1, Mathf.CeilToInt(chance.y + 1)) <= Mathf.CeilToInt(chance.x))
            {
                _particals.Play();
            }

            time = 0;
        }
    }

    #endregion
}
