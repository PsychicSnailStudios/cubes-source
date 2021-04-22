using TMPro;
using UnityEngine;

/// <summary>
/// Handles the games tutorial
/// Very last minute addition
/// </summary>
public class Tutorial : MonoBehaviour
{
	#region Fields

	private const string V = "Block the cubes falling out of the pipes and on your plants by dragging blue cubes from the oven onto the grid.";
	private const string V1 = "Don't worry, you can drag it to a different slot at any time.";
	private const string V2 = "Cubes are Stronger Together, try dropping a cube on another one";
	private const string V3 = "Great! Now make it even bigger so it can get a special ability!";
	private const string V4 = "Wonderful! Now you are all set! Keep an eye on those pipes!";

	public TMP_Text text;
	public GameObject panel;
	public Player player;

	public int progress = -1;
	float lastCheck;

	#endregion

	#region Methods

	void Update()
	{
		switch (progress)
		{
			case 0:
				Time.timeScale = 0;
				text.text = V;

				if (LevelManager.GridAmount > 0)
				{
					progress++;
					Time.timeScale = 1;
				}
				break;

			case 1:
				text.text = V1;

				if (player.Health < GameSettings.Health)
				{
					progress++;
					Time.timeScale = 0;
				}
				break;

			case 2:
				EventManager.OnBoostOvenTime.Invoke(10000f);
				text.text = V2;

				bool test = false;

				foreach (GridCube cube in LevelManager.Grid)
				{
					if (!cube.Empty)
					{
						if (cube.Cube.Level > 1)
						{
							test = true;
						}
					}
				}

				if (test)
				{
					progress++;
					Time.timeScale = 1;
				}
				break;

			case 3:
				EventManager.OnBoostOvenTime.Invoke(10000f);
				text.text = V3;

				foreach (GridCube cube in LevelManager.Grid)
				{
					if (!cube.Empty)
					{
						if (cube.Cube.Level > 2)
						{
							progress++;
							Time.timeScale = 0.4f;
						}
					}
				}
				break;

			case 4:
				text.text = V4;

				lastCheck += Time.deltaTime;

				if (lastCheck > 5)
				{
					progress++;
					Time.timeScale = 1;
					text.gameObject.SetActive(false);
					panel.SetActive(false);
				}
				break;
		}
	}

	#endregion
}
