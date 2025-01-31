using UnityEngine;

public class MoveObjectStraight : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f; // Speed of movement
    [SerializeField] private float maxFadeDistance = 3.0f; // Distance at which the object becomes most transparent
    [SerializeField] private float minAlpha = 0.3f; // Minimum transparency (0 = invisible, 1 = fully visible)

    private Material material;
    private Color originalColor;
    private Transform missCounter; // Target to fade towards

    private void Start()
    {
        material = GetComponent<Renderer>().material;
        originalColor = material.color;

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
