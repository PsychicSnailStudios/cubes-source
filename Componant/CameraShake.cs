using System.Collections;
using UnityEngine;

/// <summary>
/// Adds a shake function to the camera
/// </summary>
public class CameraShake : MonoBehaviour
{
	#region Fields

	[SerializeField]
    [Tooltip("How long the shaking lasts.")]
    float duration = 0.15f;
    [SerializeField]
    [Tooltip("How much it shakes")]
    float magnitude = 0.2f;

	#endregion

	#region Methods

	/// <summary>
	/// Shakes the camera
	/// </summary>
	/// <param name="duration">how long to shake in seconds</param>
	/// <param name="magnitude">how hard to shake</param>
	public void StartShaking()
    {
        StartCoroutine(Shake(duration, magnitude));
    }
    public void StartShaking(float duration, float magnitude)
    {
        StartCoroutine(Shake(duration, magnitude));
    }

    /// <summary>
    /// A courotine that shakes the camera
    /// </summary>
    /// <param name="duration">how long to shake</param>
    /// <param name="magnitude">how hard to shake</param>
    /// <returns></returns>
    IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 origanalPos = transform.position;

        float elapsed = 0.0f;
        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(x, y, origanalPos.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = new Vector3();
    }

	#endregion
}
