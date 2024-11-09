using UnityEngine;

public class DeadTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            collider.gameObject.GetComponent<PlayerMovement>().alive = false;

            LevelManager.Restart();
        }
    }
}
