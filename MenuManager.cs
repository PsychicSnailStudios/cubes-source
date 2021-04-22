using UnityEngine;

/// <summary>
/// Handles basic menu functions
/// </summary>
public class MenuManager : GUIManager
{
    #region Menu Methods

    public void ToHome()
    {
        _next = 0;
        transition.SetActive(true);
    }

    public void ToTutorial()
    {
        _next = 2;
        transition.SetActive(true);
    }

    public void Play()
    {
        Time.timeScale = 1 * GameSettings.TimeScale;
        GameSettings.CurrentGameState = GameState.Playing;
        _next = 1;
        transition.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }

    #endregion
}
