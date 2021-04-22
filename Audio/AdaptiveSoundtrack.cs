using UnityEngine;

/// <summary>
/// can adjust the music to fit what is happening in game
/// </summary>
public class AdaptiveSoundtrack : MonoBehaviour
{
    #region Fields

    // singleton instance
    public static AdaptiveSoundtrack instance;

    // set in inspector
    public AudioSource keys2;
    public AudioSource keys1;
    public AudioSource backing;
    public AudioSource bass;
    public AudioSource drums;

    #endregion

    #region Unity Methods

    void Awake()
    {
        // set up singleton
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

	void Start()
	{
        // start the music
        StartSong();
    }

	#endregion

	#region Methods

	void Mute(bool m)
    {
        keys2.mute = m;
        keys1.mute = m;
        backing.mute = m;
        bass.mute = m;
        drums.mute = m;
    }

    void PlayAll()
    {
        keys2.Play();
        keys1.Play();
        backing.Play();
        bass.Play();
        drums.Play();
    }

    void StartSong()
    {
        keys2.Play();
        bass.Play();
        drums.Play();
    }

    #endregion

    #region Preset Mixes

    void SetFullSong1()
    {
        keys2.mute = false;
        keys1.mute = true;
        backing.mute = false;
        bass.mute = false;
        drums.mute = false;
    }

    void SetFullSong2()
    {
        keys2.mute = true;
        keys1.mute = false;
        backing.mute = false;
        bass.mute = false;
        drums.mute = false;
    }

    void SetFullSong3()
    {
        keys2.mute = false;
        keys1.mute = false;
        backing.mute = false;
        bass.mute = false;
        drums.mute = false;
    }

    void SetDrums()
    {
        keys2.mute = true;
        keys1.mute = true;
        backing.mute = true;
        bass.mute = true;
        drums.mute = false;
    }

    void SetDrumsBass()
    {
        keys2.mute = true;
        keys1.mute = true;
        backing.mute = true;
        bass.mute = false;
        drums.mute = false;
    }

    void SetSong1()
    {
        keys2.mute = true;
        keys1.mute = false;
        backing.mute = true;
        bass.mute = false;
        drums.mute = false;
    }

    void SetSong2()
    {
        keys2.mute = false;
        keys1.mute = true;
        backing.mute = true;
        bass.mute = false;
        drums.mute = false;
    }

    void SetSong3()
    {
        keys2.mute = false;
        keys1.mute = false;
        backing.mute = true;
        bass.mute = false;
        drums.mute = false;
    }

    #endregion
}
