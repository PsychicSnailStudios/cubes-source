using TMPro;
using UnityEngine;

/// <summary>
/// Sets the text of the Text component to the name of the object
/// </summary>
[ExecuteInEditMode]
[RequireComponent(typeof(TMP_Text))]
public class GetName : MonoBehaviour
{
    #region Fields

    [Tooltip("When true uses the name of the object this is parented to.")]
    public bool UsesParent = true;

    // text reference
    TMP_Text text;

    #endregion

    #region Methods

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        // always check for null
        if (text == null)
        {
            text = GetComponent<TMP_Text>();
        }
        else
        {
            // set the text to the object name
            text.text = UsesParent ? transform.parent.name : name;
        }
    }

    #endregion
}
