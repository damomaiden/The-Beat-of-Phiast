using UnityEngine;
using System.Collections;

public class EndGameOnHit : MonoBehaviour
{
    public AudioSource soundEffect1;
    public AudioSource soundEffect2;
    public AudioSource backgroundMusic;
    public Canvas endGameCanvas; // Reference to your end game canvas
    public float endGameDelay = 3f; // Adjustable delay in seconds

    private void Start()
    {
        // Ensure the canvas starts invisible
        if (endGameCanvas != null)
        {
            endGameCanvas.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object that entered the collider is the pot
        if (other.CompareTag("Pot"))
        {
            StartCoroutine(EndGameSequence());
        }
    }

    private IEnumerator EndGameSequence()
    {
        // Log the end-game event for debugging
        Debug.Log("The pot hit the target! Game Over sequence starting...");

        // Pause background music
        if (backgroundMusic != null) backgroundMusic.Pause();

        // Play both sound effects
        if (soundEffect1 != null) soundEffect1.Play();
        if (soundEffect2 != null) soundEffect2.Play();

        // Wait for the specified delay
        yield return new WaitForSeconds(endGameDelay);

        // Show the end game canvas
        if (endGameCanvas != null)
        {
            endGameCanvas.enabled = true;
        }
        else
        {
            Debug.LogWarning("End Game Canvas not assigned in the inspector!");
        }
    }
}