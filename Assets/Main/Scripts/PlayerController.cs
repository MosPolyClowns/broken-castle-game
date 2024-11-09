/// <summary>
/// Да всё навалил в один контроллер и не умер)))
/// </summary>

using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private InputHandler _inputHandler;
    [SerializeField] private Rigidbody2D _rigidBody2D;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    [Header("Movement")]
    [SerializeField] private float _speed = 4;
    [SerializeField] private float _acceleration = 4;
    [SerializeField] private float _deceleration = 4;
    [SerializeField] private float _jumpSpeed = 11;

    private Vector3 velocity = Vector3.zero;
    private bool isGrounded = false;
    private bool isClicked = false;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        // Horizontal speed
        if (Mathf.Abs(_inputHandler.MovementInput) > 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, _inputHandler.MovementInput * _speed, _acceleration * Time.deltaTime);

            _spriteRenderer.flipX = _inputHandler.MovementInput < 0 ? true : false;
        }
        else
        {
            velocity.x = Mathf.MoveTowards(velocity.x, 0, _deceleration * Time.deltaTime);
        }

        // Vertical speed
        velocity.y = _rigidBody2D.linearVelocityY;

        if (_inputHandler.JumpTriggered)
        {
            isGrounded = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - 0.1f), Vector2.zero).collider != null;

            if (isGrounded && isClicked == false)
            {
                velocity.y = _jumpSpeed;
                isGrounded = false;
            }
            
            isClicked = true;
        }
        else
        {
            isClicked = false;
        }

        // Movement
        _rigidBody2D.linearVelocity = velocity;
    }
}
