using UnityEngine;
using UnityEngine.Tilemaps;

public class ActiveGrid : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Tilemap _tilemap;
    [SerializeField] private Collider2D _collider2D;
    [SerializeField] private ParticleSystem _particleSystem;

    [Header("Fake")]
    [SerializeField] private TileBase _defaultTileBase;
    [SerializeField] private TileBase _fakeTileBase;

    private Vector3 velocity = Vector3.zero;

    public void Activate()
    {
        Fake();
    }

    private void Fake()
    {
        _tilemap.SwapTile(_defaultTileBase, _fakeTileBase);
        _collider2D.enabled = false;
        _particleSystem.Play();
    }

    private void Update()
    {
        transform.position += velocity * Time.deltaTime;
    }
}
