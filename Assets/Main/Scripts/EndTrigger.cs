using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            LevelManager.Next();
        }
    }
}
