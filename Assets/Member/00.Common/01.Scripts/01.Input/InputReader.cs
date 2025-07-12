using System;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "PlayerInput", menuName = "SO/PlayerInput", order = 0)]
public class InputReader : ScriptableObject, Controls.IPlayerActions
{
    public Vector2 MovementKey { get; private set; }
    
    private Controls _controls;
    public event Action OnJumpEvent;
    public event Action OnMoveEvent;
    public event Action OnClickEvent;
    public event Action<Vector2> OnPointerEvent;
    
    public event Action OnAttackEvent;
    private void OnEnable()
    {
        if (_controls == null)
        {
            _controls = new Controls();
            _controls.Player.SetCallbacks(this);
        }

        _controls.Player.Enable();
    }
    
    public void OnMove(InputAction.CallbackContext context)
    {
        MovementKey = context.ReadValue<Vector2>();

        if (context.performed)
            OnMoveEvent?.Invoke();
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if(context.performed)
            OnAttackEvent?.Invoke();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if(context.performed)
            OnJumpEvent?.Invoke();
    }

    public void OnPointer(InputAction.CallbackContext context)
    {
        OnPointerEvent?.Invoke(context.ReadValue<Vector2>());
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        if(context.performed)
            OnClickEvent?.Invoke();
    }
}
