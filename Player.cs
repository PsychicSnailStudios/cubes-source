using UnityEngine;

/// <summary>
/// Handles the players health and points
/// </summary>
public class Player : MonoBehaviour
{
    #region Properties

    public int Health { get; private set; }
    public int Points { get; private set; }

	#endregion

	#region Unity Methods

	void Start()
    {
        EventManager.OnPlayerTakesDamage.AddListener(OnDamaged);
        EventManager.OnPlayerBlocksDamage.AddListener(OnPoints);
        EventManager.OnPlayerHeals.AddListener(OnHeal);

        Health = GameSettings.Health;
    }

    void Update()
    {

    }

    #endregion

    #region Event Methods

    void OnDamaged(int damage)
    {
        Health -= damage;
        Health = Mathf.Clamp(Health, 0, GameSettings.Health);

        if (Health <= 0)
		{
            EventManager.OnPlayerDies.Invoke();
            gameObject.SetActive(false);
		}
    }

    void OnPoints(int amount)
	{
        Points += amount;
	}

    void OnHeal(int amount)
    {
        Health += amount;
        Health = Mathf.Clamp(Health, 0, GameSettings.Health);
    }

    #endregion
}
