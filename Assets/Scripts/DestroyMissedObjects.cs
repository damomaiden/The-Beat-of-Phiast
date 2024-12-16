using UnityEngine;

public class DestroyMissedObjects : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object has the tag "Breakable" or "Sliceable"
        if (other.CompareTag("Breakable") || other.CompareTag("Sliceable"))
        {
            // Destroy the object
            Destroy(other.gameObject);
        }
    }
}
