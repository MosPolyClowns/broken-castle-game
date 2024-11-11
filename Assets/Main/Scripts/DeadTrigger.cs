using UnityEngine;

public class DeadTrigger : MonoBehaviour
{
    private AudioManager _audioManager;
    private LevelManager _levelManager;

    void Start()
    {
        _audioManager = AudioManager.Instance;
        _levelManager = LevelManager.Instance;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            _audioManager?.PlaySFX(_audioManager.deathAudio);

            collider.gameObject.GetComponent<PlayerMovement>().alive = false;

            _levelManager.Restart();
        }
    }
}
