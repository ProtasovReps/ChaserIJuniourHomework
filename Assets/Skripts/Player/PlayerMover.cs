using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private InputReader _input;
    [SerializeField] private float _moveSpeed;

    private CharacterController _controller;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 projectedForwardAxis = Vector3.ProjectOnPlane(_camera.transform.forward, Vector3.up).normalized;
        Vector3 projectedRightAxis = Vector3.ProjectOnPlane(_camera.transform.right, Vector3.up).normalized;
        Vector3 direction = projectedForwardAxis * _input.MoveDirection.y * _moveSpeed + projectedRightAxis * _input.MoveDirection.x * _moveSpeed + Physics.gravity;

        _controller.Move(direction * Time.deltaTime);
    }
}
