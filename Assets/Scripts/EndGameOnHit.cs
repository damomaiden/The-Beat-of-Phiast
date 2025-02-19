using UnityEngine;
using System.Collections;

public class EndGameOnHit : MonoBehaviour
{
    public AudioSource soundEffect1;
    public AudioSource soundEffect2;
    public AudioSource backgroundMusic;
    public Canvas endGameCanvas; // Reference to your end game canvas
    public Animator characterAnimator; // Reference to the Animator component of your character
    public float endGameDelay = 3f; // Adjustable delay in seconds

    private void Start()
    {
        // Ensure the canvas starts invisible
        if (endGameCanvas != null)
        {
            endGameCanvas.enabled = false;
        }

        // Set the "isCrying" parameter to true to start the crying animation after idle
        if (characterAnimator != null)
        {
            characterAnimator.SetBool("IsCrying", true);
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

        // Wait for the specified delay before showing the end game canvas
        yield return new WaitForSeconds(endGameDelay);

        // Trigger the defeat animation by setting the "Defeated" trigger
        if (characterAnimator != null)
        {
            characterAnimator.SetTrigger("Defeated");
        }

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
