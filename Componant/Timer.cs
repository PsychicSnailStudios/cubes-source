using UnityEngine;

/// <summary>
/// A timer
/// </summary>
public class Timer : MonoBehaviour
{
	#region Fields
	
	// timer duration
	float totalSeconds = 0;
	
	// timer execution
	float elapsedSeconds = 0;
	bool running = false;
	bool paused = false;

	// support for Finished property
	bool started = false;
	
	#endregion
	
	#region Properties
	
	/// <summary>
	/// Sets the duration of the timer
	/// The duration can only be set if the timer isn't currently running
	/// </summary>
	/// <value>duration</value>
	public float Duration
    {
		set
        {
			if (!running)
            {
				totalSeconds = value;
			}
		}
	}
	
	/// <summary>
	/// Gets whether or not the timer has finished running
	/// This property returns false if the timer has never been started
	/// </summary>
	/// <value>true if finished; otherwise, false.</value>
	public bool Finished
    {
		get { return started && !running; } 
	}
	
	/// <summary>
	/// Gets whether or not the timer is currently running
	/// </summary>
	/// <value>true if running; otherwise, false.</value>
	public bool Running
    {
		get { return running; }
	}

	/// <summary>
	/// Gets whether or not the timer is paused
	/// </summary>
	/// <value>true if paused; otherwise, false.</value>
	public bool Paused
	{
		get { return paused; }
	}

	#endregion

	#region Methods

	/// <summary>
	/// Update is called once per frame
	/// </summary>
	void Update()
    {	
		// update timer and check for finished
		if (running)
        {
			elapsedSeconds += Time.deltaTime;
			if (elapsedSeconds >= totalSeconds)
            {
				running = false;
			}
		}
	}
	
	/// <summary>
	/// Runs the timer
	/// </summary>
	public void Run()
    {	
		// only run with valid duration
		if (totalSeconds > 0)
        {
			started = true;
			running = true;
			paused = false;
            elapsedSeconds = 0;
		}
	}

	/// <summary>
	/// Stops the timer
	/// </summary>
	public void Stop()
	{
		running = false;
		paused = false;
		elapsedSeconds = 0;
	}

	/// <summary>
	/// Pauses the timer
	/// </summary>
	public void Pause()
	{
		// only pause if already running
		if (running)
		{
			running = false;
			paused = true;
		}
	}

	/// <summary>
	/// Resumes the timer if paused
	/// </summary>
	public void Resume()
	{
		// only resume if paused
		if (paused)
		{
			running = true;
			paused = false;
		}
	}

	#endregion
}
