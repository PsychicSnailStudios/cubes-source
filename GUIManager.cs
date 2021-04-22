using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Base Class for handling GUI interaction
/// </summary>
public class GUIManager : MonoBehaviour
{
    #region Fields

    public GameObject transition;

    public Tutorial tut;

    protected int _next;

    #endregion

    #region Methods

    /// <summary>
    /// Loads the next scene
    /// </summary>
    public void Trigger()
    {
        SceneManager.LoadScene(_next);
    }

    /// <summary>
    /// Starts the tutorial
    /// </summary>
    public void StartTut()
    {
        if (tut != null)
        {
            tut.progress = 0;
        }
    }

    #endregion
}
