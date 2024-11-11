/// <summary>
/// Да, всё навалил в один контроллер и не умер)))
/// </summary>

using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private InputHandler _inputHandler;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    private AudioManager _audioManager;

    [Header("State")]
    public bool alive = true;
    public bool stoped = false;

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

    void Start()
    {
        _audioManager = AudioManager.Instance;
    }

    void FixedUpdate()
    {
        if (stoped == true)
        {
            return;
        }

        if (alive == false)
        {
            _rigidbody2D.linearVelocityX = 0;
            return;
        }

        // Horizontal speed
        if (Mathf.Abs(_inputHandler.MovementInput) > 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, _inputHandler.MovementInput * _speed, _acceleration * Time.deltaTime);
            if (groundBuffer < 0.001f)
            {
                _audioManager?.PlayWithGapSFX(_audioManager.runAudio, 0.15f);
            }
        }
        else
        {
            velocity.x = Mathf.MoveTowards(velocity.x, 0, _deceleration * Time.deltaTime);
        }

        // Vertical speed
        velocity.y = _rigidbody2D.linearVelocityY;

        if (_inputHandler.JumpTriggered) 
        {
            if (isClicked == false) jumpBuffer = 0;
            isClicked = true;
        }
        else
        {
            isClicked = false;
        }

        Collider2D hitCollider = Physics2D.Linecast(
            new Vector2(transform.position.x - 0.2f * transform.localScale.x, transform.position.y - 0.1f),
            new Vector2(transform.position.x + 0.2f * transform.localScale.x, transform.position.y - 0.1f)
        ).collider;

        if (hitCollider && hitCollider.tag == "Ground")
        {
            if (groundBuffer > 0.001f)
            {
                _audioManager?.PlaySFX(_audioManager.landAudio);
            }

            groundBuffer = 0;
        }
        else
        {
            groundBuffer += Time.deltaTime;
        }

        if (jumpBuffer < _jumpBufferSize)
        {
            if (groundBuffer < _groundBufferSize)
            {
                velocity.y = _jumpSpeed;
                _audioManager?.PlaySFX(_audioManager.jumpAudio);
            }
        }

        jumpBuffer += Time.deltaTime;

        // Movement
        _rigidbody2D.linearVelocity = velocity;
    }
}
