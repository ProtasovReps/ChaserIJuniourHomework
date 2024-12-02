using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour
{
    private PlayerInput _input;

    public Vector3 MoveDirection { get; private set; }
    public Vector2 RotationDirection { get; private set; }

    private void Awake()
    {
        _input = new PlayerInput();
    }

    private void OnEnable()
    {
        _input.Enable();

        _input.Player.Movement.performed += OnMovementPerformed;
        _input.Player.Movement.canceled += OnMovementCanceled;
        _input.Player.Rotation.performed += OnRotationPerformed;
        _input.Player.Rotation.canceled += OnRotationCanceled;
    }

    private void OnDisable()
    {
        _input.Disable();

        _input.Player.Movement.performed -= OnMovementPerformed;
        _input.Player.Movement.canceled -= OnMovementCanceled;
        _input.Player.Rotation.performed -= OnRotationPerformed;
        _input.Player.Rotation.canceled -= OnRotationCanceled;
    }

    private void OnMovementPerformed(InputAction.CallbackContext context)
    {
        MoveDirection = context.ReadValue<Vector2>();
    }

    private void OnMovementCanceled(InputAction.CallbackContext context)
    {
        MoveDirection = Vector2.zero;
    }

    private void OnRotationPerformed(InputAction.CallbackContext context)
    {
        RotationDirection = context.ReadValue<Vector2>();
    }

    private void OnRotationCanceled(InputAction.CallbackContext context)
    {
        RotationDirection = Vector2.zero;
    }
}
