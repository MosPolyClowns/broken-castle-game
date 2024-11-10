using Unity.VisualScripting;
using UnityEngine;

public class ScaleZone : MonoBehaviour
{
    [SerializeField] private Vector2 _scaleFactorRLeft = new Vector2(1, 1);
    [SerializeField] private Vector2 _scaleFactorRight = new Vector2(2, 2);

    private float _width;

    void Start()
    {
        _width = transform.GetComponent<BoxCollider2D>().size[0];
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            float progress = (collider.transform.position.x - (transform.position.x - _width / 2)) / (_width * 2);
            
            Vector2 scaleModifier = new Vector2(
                Mathf.Lerp(_scaleFactorRLeft.x, _scaleFactorRight.x, progress),
                Mathf.Lerp(_scaleFactorRLeft.y, _scaleFactorRight.y, progress)
            );

            collider.transform.localScale = new Vector3(scaleModifier.x, scaleModifier.y, 1);
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
