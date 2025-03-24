using UnityEngine;
using UnityEngine.InputSystem;

public class RotateObject : MonoBehaviour
{
    [SerializeField] private InputActionAsset _actions;

    public InputActionAsset actions
    {
        get => _actions;
        set => _actions = value;
    }

    protected InputAction LeftClickPressedInputAction { get; set; }

    protected InputAction MouseLookInputAction { get; set; }

    private bool _rotateAllowed;
    private Camera _camera;
    [SerializeField] private float _speed;
    [SerializeField] private bool _inverted;

    private void Awake()
    {
        InitializeInputSystem();
    }
    
    private void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;

        //_camera = Camera.main;
    }

    private void Update()
    {
        if (!_rotateAllowed)
        return;

        Vector2 MouseDelta = GetMouseLookInput();

        MouseDelta *= _speed * Time.deltaTime;

        transform.Rotate(Vector3.up * (_inverted ? 1 : -1), MouseDelta.x, Space.World);
        transform.Rotate(Vector3.right * (_inverted ? -1 : 1), MouseDelta.y, Space.World);
    }

    private void InitializeInputSystem()
    {
        LeftClickPressedInputAction = actions.FindAction("Left Click");
        if (LeftClickPressedInputAction != null)
        {
            LeftClickPressedInputAction.started += OnLeftClickPressed;
            LeftClickPressedInputAction.performed += OnLeftClickPressed;
            LeftClickPressedInputAction.canceled += OnLeftClickPressed;
        }

        MouseLookInputAction = actions.FindAction("Mouse Look");

        actions.Enable();
    }

    protected virtual void OnLeftClickPressed(InputAction.CallbackContext context)
    {
        if (context.started || context.performed)
        _rotateAllowed = true;
        else if (context.canceled)
        _rotateAllowed = false;
    }

    protected virtual Vector2 GetMouseLookInput()
    {
        if (MouseLookInputAction != null)
        return MouseLookInputAction.ReadValue<Vector2>();

        return Vector2.zero;
    }
}
