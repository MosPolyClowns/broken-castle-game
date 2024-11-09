/// <summary>
/// Да всё навалил в один контроллер и не умер)))
/// </summary>

using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private InputHandler _inputHandler;
    [SerializeField] private Rigidbody2D _rigidBody2D;

    [Header("State")]
    public bool alive = true;

    [Header("Movement")]
    [SerializeField] private float _speed = 4;
    [SerializeField] private float _acceleration = 4;
    [SerializeField] private float _deceleration = 4;
    [SerializeField] private float _jumpSpeed = 11;
    [SerializeField] private float _jumpBufferSize = 0.007f;
    [SerializeField] private float _groundBufferSize = 0.007f;

    private Vector3 velocity = Vector3.zero;

    private float jumpBuffer = 10;
    private float groundBuffer = 0;

    private bool isClicked = false;

    void FixedUpdate()
    {
        if (alive == false) return;

        // Horizontal speed
        if (Mathf.Abs(_inputHandler.MovementInput) > 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, _inputHandler.MovementInput * _speed, _acceleration * Time.deltaTime);
        }
        else
        {
            velocity.x = Mathf.MoveTowards(velocity.x, 0, _deceleration * Time.deltaTime);
        }

        // Vertical speed
        velocity.y = _rigidBody2D.linearVelocityY;

        jumpBuffer += Time.deltaTime;
        groundBuffer += Time.deltaTime;

        if (_inputHandler.JumpTriggered) 
        {
            if (isClicked == false) jumpBuffer = 0;
            isClicked = true;
        }
        else
        {
            isClicked = false;
        }

        Collider2D hitCollider = Physics2D.Linecast(new Vector2(transform.position.x - 0.2f, transform.position.y - 0.1f), new Vector2(transform.position.x + 0.2f, transform.position.y - 0.1f)).collider;

        if (hitCollider && hitCollider.tag == "Ground") groundBuffer = 0;

        if (jumpBuffer < _jumpBufferSize)
        {
            if (groundBuffer < _groundBufferSize)
            {
                velocity.y = _jumpSpeed;
            }
        }

        // Movement
        _rigidBody2D.linearVelocity = velocity;
    }
}
