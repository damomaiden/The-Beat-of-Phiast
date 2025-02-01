using UnityEngine;
//using UnityEngine.SceneManagement; // For scene management if needed

public class EndGameOnHit : MonoBehaviour
{
    public AudioSource soundEffect1; // Assign in Inspector
    public AudioSource soundEffect2; // Assign in Inspector
    public AudioSource backgroundMusic; // Assign in Inspector

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object that entered the collider is the pot
        if (other.CompareTag("Pot"))
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        // Log the end-game event for debugging
        Debug.Log("The pot hit the target! Game Over.");

        // Pause background music
        if (backgroundMusic != null) backgroundMusic.Pause();

        // Play both sound effects
        if (soundEffect1 != null) soundEffect1.Play();
        if (soundEffect2 != null) soundEffect2.Play();

        // Stop gameplay by pausing time
        Time.timeScale = 0;

        // Optionally reload the current scene to reset the game
        // SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        // Optionally quit the application (for builds only)
        //Application.Quit();
    }
}
