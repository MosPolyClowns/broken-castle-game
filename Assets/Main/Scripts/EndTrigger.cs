using UnityEngine;

public class EndTrigger : MonoBehaviour
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
            _audioManager?.PlaySFX(_audioManager.winAudio);

            LevelManager.Next();
        }
    }
}
