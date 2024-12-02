using UnityEngine;

public class PlayerRotator : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private InputReader _input;
    [SerializeField] private float _verticalSensativity;
    [SerializeField] private float _horizontalSensativity;
    [SerializeField] private float _maxUpAngle;

    private float _cameraAngle = 0f;

    private void Awake()
    {
        _cameraAngle = _camera.transform.localEulerAngles.x;
    }

    private void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        _cameraAngle -= _input.RotationDirection.y * _verticalSensativity;
        _cameraAngle = Mathf.Clamp(_cameraAngle, -_maxUpAngle, _maxUpAngle);

        _camera.transform.localEulerAngles = Vector3.right * _cameraAngle;

        transform.Rotate(new Vector2(0f, _input.RotationDirection.x * _horizontalSensativity));
    }
}
