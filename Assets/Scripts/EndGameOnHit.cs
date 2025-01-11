using UnityEngine;
//using UnityEngine.SceneManagement; // For scene management if needed

public class EndGameOnHit : MonoBehaviour
{
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

        // Stop gameplay by pausing time
         Time.timeScale = 0;

        // Optionally reload the current scene to reset the game
        // SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        // Optionally quit the application (for builds only)
        //Application.Quit();
    }
}
