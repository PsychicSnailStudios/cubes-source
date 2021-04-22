using UnityEngine;

/// <summary>
/// Destroys the game object after its life time runs out
/// </summary>
public class LifeSpan : MonoBehaviour
{
    #region Fields

    [SerializeField]
    [Tooltip("How many seconds the game object will sick around before killing it's self")]
    float lifeSpan = 1;
    float time = 0;

    #endregion

    #region Properties

    /// <summary>
    /// How long until the object is destroyed in seconds
    /// </summary>
    public float Life
    { 
        set { lifeSpan = value; }
    }

    #endregion

    #region Methods

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        // increment time
        time += Time.deltaTime;

        if (time >= lifeSpan)
        {
            // destroy if time has run out
            Destroy(gameObject);
        }
    }

    #endregion
}
