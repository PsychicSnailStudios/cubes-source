using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles starting the game levels
/// </summary>
public class LevelManager : MonoBehaviour
{
    #region Fields

    static LevelManager instance;

    public List<GridCube> grids;

    public static int GridAmount { get; private set; }
    public static List<GridCube> Grid { get => instance.grids; }

    #endregion

    #region Methods

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        EventManager.OnEndGridMove.AddListener(UpdateGrid);

        UpdateGrid();
    }

    /// <summary>
    /// Gets the number of grid cells
    /// </summary>
    void UpdateGrid()
	{
        int count = 0;

		foreach (GridCube item in grids)
		{
            if (!item.Empty) count++;
		}

        GridAmount = count;
	}

    #endregion
}
