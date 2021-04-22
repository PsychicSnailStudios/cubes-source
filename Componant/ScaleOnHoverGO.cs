using UnityEngine;

/// <summary>
/// Scales the object this component is attached to when it is interacted with
/// </summary>
public class ScaleOnHoverGO : MonoBehaviour
{
	#region Fields

	[Tooltip("The scale of the object when the mouse is hovering over it.")]
	public float highlightedScale;
	[Tooltip("The scale of the object when the mouse clicks it.")]
	public float pressedScale;

	[Tooltip("How long it takes to scale up or down.")]
	public float scaleTime;

	// save the original scale so it can return to normal
	Vector3 _scale;

	#endregion

	#region Methods

	private void OnMouseEnter()
	{
		_scale = transform.localScale;
		LeanTween.scale(gameObject, _scale * highlightedScale, scaleTime).setIgnoreTimeScale(true);
	}

	private void OnMouseExit()
	{
		LeanTween.scale(gameObject, _scale, scaleTime).setIgnoreTimeScale(true);
	}

	private void OnMouseDown()
	{
		LeanTween.scale(gameObject, _scale * pressedScale, scaleTime).setIgnoreTimeScale(true);
	}

	#endregion
}