using UnityEngine;
using UnityEngine.Tilemaps;

public class ActiveGrid : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Tilemap _tilemap;
    [SerializeField] private Collider2D _collider2D;
    [SerializeField] private ParticleSystem _particleSystem;

    [Header("Type")]
    [SerializeField] private string _type = "Fake";

    [Header("Fake")]
    [SerializeField] private TileBase _defaultTileBase;
    [SerializeField] private TileBase _fakeTileBase;

    [Header("Move")]
    [SerializeField] private Vector2 _targetVelocity;

    private bool _activated = false;

    private Vector3 velocity = Vector3.zero;

    public void Activate()
    {
        if (_activated == false)
        {
            _activated = true;

            switch (_type)
            {
                case "Fake":
                    Fake();
                    break;
                case "Move":
                    Move();
                    break;
            }
            
        }
    }

    private void Fake()
    {
        _tilemap.SwapTile(_defaultTileBase, _fakeTileBase);
        _collider2D.enabled = false;
        _particleSystem.Play();
    }

    private void Move()
    {
        velocity = new Vector3(_targetVelocity.x, _targetVelocity.y, 0);
        _particleSystem.Play();
    }

    private void Update()
    {
        transform.position += velocity * Time.deltaTime;
    }
}
