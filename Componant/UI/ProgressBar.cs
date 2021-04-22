using UnityEngine.UI;
using UnityEngine;

/// <summary>
/// A standard progress bar that displays the value as a percentage of the maximum.
/// </summary>
[ExecuteInEditMode()]
public class ProgressBar : MonoBehaviour
{
	#region Fields
	
    // offset support
	public float minimum;
    public float maximum;
    // fill support
    public float value;
    public Color color;
    public Image mask;
    public Image fill;

	#endregion

    #region Methods

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        SetCurrentFill();
    }

    /// <summary>
    /// Sets the progress bar's fill based off of the current value
    /// </summary>
    void SetCurrentFill()
	{
        // get fill percentage
        float currentOffset = value - minimum;
        float maximumOffset = maximum - minimum;
        float fillAmount = currentOffset / maximumOffset;
        // set mask fill to our current fill percent
        mask.fillAmount = fillAmount;
        // update color
        fill.color = color;
	}

    #endregion
}
