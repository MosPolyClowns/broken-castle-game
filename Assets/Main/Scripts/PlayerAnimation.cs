using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Rigidbody2D _rigidBody2D;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Animator _animator;
    [SerializeField] private PlayerMovement _playerMovement;

    void Update()
    {
        if (_rigidBody2D.linearVelocityX > 0.001f)
        {
            _spriteRenderer.flipX = false;
        }
        else if (_rigidBody2D.linearVelocityX < -0.001f)
        {
            _spriteRenderer.flipX = true;
        }

        _animator.SetFloat("velocityY", Mathf.Abs(_rigidBody2D.linearVelocityX));
        _animator.SetBool("alive", _playerMovement.alive);
        }
}
