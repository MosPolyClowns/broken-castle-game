using UnityEngine;

public class TrapTrigger : MonoBehaviour
{
    [SerializeField] private GameObject[] _activeGrid;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            for (int i = 0; i < _activeGrid.Length; i++)
            {
                _activeGrid[i].GetComponent<ActiveGrid>().Activate();
            }
        }
    }
}
