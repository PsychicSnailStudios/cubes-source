using UnityEngine;

/// <summary>
/// hurts the player if it hits their plants
/// </summary>
public class DamageCube : MonoBehaviour
{
    #region Fields

    [SerializeField] int _damage;
    [SerializeField] ParticleSystem burst;

    #endregion

    #region Methods

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != Tags.DamageCube)
        {
            OnCollision(collision.gameObject.tag, collision.gameObject);
        }
    }

    void OnCollision(string tag, GameObject cObject)
    {
        switch (tag)
        {
            case Tags.Health:
                EventManager.OnPlayerTakesDamage.Invoke(_damage);
                break;

            case Tags.ShieldCube:

                cObject.GetComponent<ShieldCube>().Damage(_damage);
                EventManager.OnPlayerBlocksDamage.Invoke(1);
                break;
        }

        // UNITY PARTICLE SYSTEM
        Instantiate(burst, transform.position, Quaternion.identity);

        // play sound
        AudioManager.Play(AudioFile.Shatter, AudioTrack.Block);

        // destroy it
        // TODO: replace with object pooling
        Destroy(gameObject);
    }

    #endregion
}
