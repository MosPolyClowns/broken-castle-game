using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private InputActionAsset _inputActions;

    private InputAction _moveAction;
    private InputAction _jumpAction;

    public float MovementInput { get; private set; }
    public bool JumpTriggered { get; private set; }

    private void OnEnable()
    {
        _moveAction.Enable();
        _jumpAction.Enable();
    }

    private void OnDisable()
    {
        _moveAction.Disable();
        _jumpAction.Disable();
    }

    private void Awake()
    {
        _moveAction = _inputActions.FindActionMap("Player").FindAction("Move");
        _jumpAction = _inputActions.FindActionMap("Player").FindAction("Jump");

        _moveAction.performed += context => MovementInput = context.ReadValue<float>();
        _moveAction.canceled += context => MovementInput = 0;

        _jumpAction.performed += context => JumpTriggered = true;
        _jumpAction.canceled += context => JumpTriggered = false;
    }
}
