using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Chaser : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _squareMaxDistance = 1f;
    [SerializeField] private float _moveSpeed = 3f;
    [SerializeField] private DirectionFinder _directionFinder;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.freezeRotation = true;
    }

    private void FixedUpdate()
    {
        Chase();
    }

    private void Chase()
    {
        Vector3 offset = _target.position - transform.position;

        if (Vector3.SqrMagnitude(offset) <= _squareMaxDistance)
            return;

        Vector3 projectedForwardAxis = _directionFinder.GetProjectedDirection(offset);

        _rigidbody.velocity = projectedForwardAxis + _moveSpeed * Time.fixedDeltaTime * Physics.gravity;
    }
}
