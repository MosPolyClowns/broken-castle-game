using UnityEngine;

public class ScaleZone : MonoBehaviour
{
    [SerializeField] private Vector2 _scaleFactorRLeft = new Vector2(1, 1);
    [SerializeField] private Vector2 _scaleFactorRight = new Vector2(2, 2);
    [SerializeField] private float _pitchFactorLeft = 1;
    [SerializeField] private float _pitchFactorRight = 1;

    private float _width;
    private float _defaultEdgeRadius;

    void Start()
    {
        _width = transform.GetComponent<BoxCollider2D>().size[0];
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            _defaultEdgeRadius = ((BoxCollider2D)collider).edgeRadius;
        }
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

            float pitchModifier = Mathf.Lerp(_pitchFactorLeft, _pitchFactorRight, progress);

            collider.transform.localScale = new Vector3(scaleModifier.x, scaleModifier.y, 1);
            AudioManager.Instance.SetSFXPitch(pitchModifier);

            ((BoxCollider2D)collider).edgeRadius = _defaultEdgeRadius * scaleModifier.y;
        }
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            collider.transform.localScale = Vector3.one;
            AudioManager.Instance.SetSFXPitch(1);
        }
    }
}
