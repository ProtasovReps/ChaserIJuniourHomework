using UnityEngine;

public class DirectionFinder : MonoBehaviour
{
    [SerializeField] private float _sphereRadius = 1f;
   
    public Vector3 GetProjectedDirection(Vector3 direction)
    {
        Vector3 normal = GetGroundNormal();

        return Vector3.Cross(Vector3.Cross(normal, direction), normal);
    }

    private Vector3 GetGroundNormal()
    {
        if (Physics.SphereCast(transform.position, _sphereRadius, Vector3.down, out RaycastHit hit) == false)
            return Vector3.zero;

        return hit.normal;
    }
}
