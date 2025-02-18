using UnityEngine;

public class MoveObjectStraight : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f; // Speed of movement
    [SerializeField] private float maxFadeDistance = 3.0f; // Distance at which the object becomes most transparent
    [SerializeField] private float minAlpha = 0.3f; // Minimum transparency (0 = invisible, 1 = fully visible)
    [SerializeField] private Vector3 rotationSpeed = new Vector3(0f, 90f, 0f); // Rotation speed in degrees per second

    private Material material;
    private Color originalColor;
    private Transform missCounter; // Target to fade towards
    private Transform visualRotationTransform; // Child object for visual rotation

    private void Start()
    {
        // Store the original scale before any modifications
        Vector3 originalScale = transform.localScale;

        // Create a child object for visual rotation
        GameObject visualObject = new GameObject("VisualRotation");
        visualRotationTransform = visualObject.transform;
        visualRotationTransform.SetParent(transform);
        visualRotationTransform.localPosition = Vector3.zero;
        visualRotationTransform.localRotation = Quaternion.identity;

        // Move only the visual components to the child object
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        MeshFilter meshFilter = GetComponent<MeshFilter>();

        // Create new components on child object
        MeshRenderer newRenderer = visualObject.AddComponent<MeshRenderer>();
        MeshFilter newFilter = visualObject.AddComponent<MeshFilter>();

        // Copy the mesh and material
        newRenderer.material = meshRenderer.material;
        newFilter.mesh = meshFilter.mesh;
        material = newRenderer.material;
        originalColor = material.color;

        // Set the child object's scale to match the original object
        visualRotationTransform.localScale = Vector3.one;

        // Disable only the visual components on the parent
        meshRenderer.enabled = false;

        // Keep the parent's scale for colliders
        transform.localScale = originalScale;

        // Find the MissCounter object by tag
        GameObject missCounterObj = GameObject.FindGameObjectWithTag("MissCounter");
        if (missCounterObj)
        {
            missCounter = missCounterObj.transform;
        }
        else
        {
            Debug.LogError("MissCounter object not found! Make sure it's tagged correctly.");
        }
    }

    private void Update()
    {
        // Move the object backward along its local Z-axis (towards the player)
        transform.position += -transform.forward * moveSpeed * Time.deltaTime;

        // Rotate only the visual child object
        visualRotationTransform.Rotate(rotationSpeed * Time.deltaTime);

        // Apply fading logic if MissCounter exists
        if (missCounter)
        {
            float distance = Vector3.Distance(transform.position, missCounter.position);
            // Normalize alpha based on distance, ensuring it never goes fully invisible
            float alpha = Mathf.Clamp(distance / maxFadeDistance, minAlpha, 1f);
            Color newColor = originalColor;
            newColor.a = alpha;
            material.color = newColor;
        }
    }
}