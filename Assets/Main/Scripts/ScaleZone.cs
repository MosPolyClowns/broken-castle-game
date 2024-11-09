using Unity.VisualScripting;
using UnityEngine;

public class ScaleZone : MonoBehaviour
{
    [SerializeField] private float _scaleFactor;

    private float _width;

    void Start()
    {
        _width = transform.GetComponent<BoxCollider2D>().size[0];
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            float scaleModifier = Mathf.Lerp(1, _scaleFactor, (collider.transform.position.x - (transform.position.x - _width / 2)) / (_width * 2));

            collider.transform.localScale = new Vector3(scaleModifier, scaleModifier, 1);
        }
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            collider.transform.localScale = Vector3.one;
        }
    }
}
