using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Scales the UI this component is attached to when it is interacted with
/// </summary>
public class ScaleOnHoverUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
	#region Fields

	[Tooltip("The scale of the object when the mouse is hovering over it.")]
	float highlightedScale;
	[Tooltip("The scale of the object when the mouse clicks it.")]
	float pressedScale;

	[Tooltip("How long it takes to scale up or down.")]
	public float scaleTime;

	[Tooltip("The sound the object plays when the mouse hovers over it.")]
	public AudioClip hoverSound;
	[Tooltip("The sound the object plays when the mouse clicks it.")]
	public AudioClip clickSound;

	#endregion

	#region Methods

	public void OnPointerDown(PointerEventData eventData)
	{
		LeanTween.scale(gameObject, pressedScale.FloatToVector3(), scaleTime).setIgnoreTimeScale(true);
		if (clickSound != null)
		{
			AudioManager.Play(clickSound, AudioTrack.UI);
		}
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		LeanTween.scale(gameObject, highlightedScale.FloatToVector3(), scaleTime).setIgnoreTimeScale(true);
		if (hoverSound != null)
		{
			AudioManager.Play(hoverSound, AudioTrack.UI);
		}
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		LeanTween.scale(gameObject, Vector3.one, scaleTime).setIgnoreTimeScale(true);
	}

	#endregion
}