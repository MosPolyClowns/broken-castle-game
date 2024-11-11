using UnityEngine;

public class DeadTrigger : MonoBehaviour
{
    private AudioManager _audioManager;

    void Start()
    {
        _audioManager = AudioManager.Instance;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            _audioManager?.PlaySFX(_audioManager.deathAudio);

            collider.gameObject.GetComponent<PlayerMovement>().alive = false;

            LevelManager.Restart();
        }
    }
}
