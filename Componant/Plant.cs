using UnityEngine;

/// <summary>
/// Handles the plants interactions
/// </summary>
[RequireComponent(typeof(Animator))]
public class Plant : MonoBehaviour
{
    Animator _anim;

    #region Methods

    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _anim.SetTrigger("Trigger");
    }

    #endregion
}
