using UnityEngine;

/// <summary>
/// makes the animator system randomly play
/// </summary>
[RequireComponent(typeof(Animator))]
public class RandomAnimation : MonoBehaviour
{
    #region Fields

    [Tooltip("how often to try and play.")]
    public float interval = 5f;
    [Tooltip("The chance of playing")]
    public Vector2 chance = new Vector2(1, 10);

    float time;
    Animator _anim;

    #endregion

    #region Methods

    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    void Update()
    {
        // increment time
        time += Time.deltaTime;

        if (time >= interval)
        {
            if (Random.Range(1, Mathf.CeilToInt(chance.y + 1)) <= Mathf.CeilToInt(chance.x))
            {
                _anim.SetTrigger("Trigger_Animation");
            }

            time = 0;
        }
    }

    #endregion
}
