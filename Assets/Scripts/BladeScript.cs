using UnityEngine;

public class BladeScript : MonoBehaviour
{
    public float slicingSpeedThreshold = 1.0f; // Minimum speed for slicing
    private Vector3 previousPosition;
    public Vector3 bladeDirection { get; private set; }

    void Update()
    {
        // Calculate blade direction and update position
        bladeDirection = (transform.position - previousPosition).normalized;
        previousPosition = transform.position;
    }

    public bool IsSlicing()
    {
        float speed = (transform.position - previousPosition).magnitude / Time.deltaTime;
        return speed > slicingSpeedThreshold;
    }
}
