using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour, InputSystem_Actions.IPlayerActions
{
    [SerializeField] private Camera _mainCamera;
    private InputSystem_Actions _inputActions;

    public ReactiveProperty<Vector2> MovementDirection { get; } = new ReactiveProperty<Vector2>();

    private void Awake()
    {
        _inputActions = new InputSystem_Actions();
        _inputActions.Player.SetCallbacks(this);
    }

    private void OnEnable()
    {
        _inputActions.Player.Enable();
    }

    private void OnDisable()
    {
        _inputActions.Player.Disable();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        Vector3 worldDirection = _mainCamera.transform.TransformDirection(new Vector3(input.x, 0, input.y));
        worldDirection.y = 0;
        worldDirection.Normalize();

        MovementDirection.Value = new Vector2(worldDirection.x, worldDirection.z);
        //_playerViewModel.UpdateMovementInput(MovementDirection.Value);
    }

    // Реализация остальных методов IPlayerActions
    public void OnLook(UnityEngine.InputSystem.InputAction.CallbackContext context) { }
    public void OnInteract(UnityEngine.InputSystem.InputAction.CallbackContext context) { }

}
