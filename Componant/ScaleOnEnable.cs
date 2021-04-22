using UnityEngine;

/// <summary>
/// Scales the object up from Vector.Zero when it is enabled
/// </summary>
public class ScaleOnEnable : MonoBehaviour
{
    #region Fields

    [Tooltip("how long it takes to scale the object")]
    public float time;
    [Tooltip("how long to wait before scaling the object")]
    public float delay;

    Vector3 _scale;
    bool _scaled = false;
    float _time;

    #endregion

    #region Methods

    void OnEnable()
    {
        _scale = transform.localScale;
        transform.localScale = Vector3.zero;

        _time = delay;
    }

    void OnDisable()
    {
        _scaled = false;
    }

    void Update()
    {
        // make sure we are only scaling once
        if (!_scaled)
        {
            // decrement time
            _time -= Time.unscaledDeltaTime;

            if (_time <= 0)
            {
                LeanTween.scale(gameObject, _scale, time).setIgnoreTimeScale(true);
                _scaled = true;
                _time = delay;
            }
        }
    }

    #endregion
}
