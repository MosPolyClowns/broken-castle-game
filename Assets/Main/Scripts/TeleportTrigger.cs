using UnityEngine;

public class TeleportTrigger : MonoBehaviour
{
    [SerializeField] private Transform _destination;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            collider.transform.position = _destination.position;
        }
    }
}
