using UnityEngine;

/// <summary>
/// Triggers scene transition events
/// </summary>
public class SceneTrans : MonoBehaviour
{
    public GUIManager uim;

    public void Trigger()
	{
		uim.Trigger();
	}

	public void End()
	{
		uim.StartTut();
	}
}
