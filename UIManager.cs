using TMPro;
using UnityEngine;

/// <summary>
/// Manages the UI in the game level
/// </summary>
public class UIManager : GUIManager
{
    #region Fields

    public bool useBlur = true;

    [SerializeField] Player player;
    [SerializeField] CubeOven oven;

    [SerializeField] ProgressBar timer;
    [SerializeField] ProgressBar healthBar;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text highScoreText;
    [SerializeField] TMP_Text endScoreText;

    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject pausePanel;
    [SerializeField] GameObject pauseButton;
    [SerializeField] GameObject blurPanel;

    bool _paused = false;

    #endregion

    #region Unity Methods

    void Start()
    {
        EventManager.OnPlayerDies.AddListener(GameOver);

        healthBar.value = GameSettings.Health;
        healthBar.maximum = GameSettings.Health;
        timer.value = 0;
        timer.maximum = GameSettings.CubeBakeTime;
    }

    void Update()
    {
        healthBar.value = player.Health;
        timer.value = oven.BakeTime;

        scoreText.text = player.Points.ToString();

		if (Input.GetKeyUp(KeyCode.Escape))
		{
            TogglePause();
		}
    }

	#endregion

	#region Event Methods

    /// <summary>
    /// Ends the game
    /// </summary>
	void GameOver()
    {
        gameOverPanel.SetActive(true);

        Time.timeScale = 0;

        if (player.Points > GameSettings.HighScore)
		{
            GameSettings.SetHighScore(player.Points);
            GameSettings.Save();
		}

        endScoreText.text = $"SCORE: {player.Points}";
        highScoreText.text = $"HIGH SCORE: {GameSettings.HighScore}";
    }
    #endregion

    #region Menu Methods

    public void ToHome()
    {
        UnPause();
        GameSettings.CurrentGameState = GameState.NoGame;
        _next = 0;
        transition.SetActive(true);
    }

    public void Play()
    {
        UnPause();
        GameSettings.CurrentGameState = GameState.Playing;
        _next = 1;
        transition.SetActive(true);
    }

    public void Pause()
    {
        EventManager.OnTimeChange.Invoke(false);
        GameSettings.CurrentGameState = GameState.Paused;
        _paused = true;
        Time.timeScale = 0;
        pausePanel.SetActive(true);
        pauseButton.SetActive(false);
        blurPanel.SetActive(true);
    }

    public void UnPause()
    {
        Time.timeScale = 1 * GameSettings.TimeScale;
        EventManager.OnTimeChange.Invoke(true);
        GameSettings.CurrentGameState = GameState.Playing;
        _paused = false;
        pausePanel.SetActive(false);
        pauseButton.SetActive(true);
        blurPanel.SetActive(false);
    }

    public void Quit()
    {
        UnPause();
        Application.Quit();
    }

    void TogglePause()
    {
        if (_paused)
        {
            UnPause();
        }
        else
        {
            Pause();
        }
    }

    #endregion
}
