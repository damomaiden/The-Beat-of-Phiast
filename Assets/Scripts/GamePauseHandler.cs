using System.Collections.Generic;
using UnityEngine.Playables;
using UnityEngine;

public class GamePauseHandler : MonoBehaviour
{
    [SerializeField] private List<GameObject> objectsToPause;
    [SerializeField] private Animator playerAnimator;  // Reference to the player's animator

    private bool hasWeaponInLeftHand = false;
    private bool hasWeaponInRightHand = false;

    public void Start()
    {
        PauseGame();
    }

    public void PauseGame()
    {
        foreach (GameObject obj in objectsToPause)
        {
            if (obj.TryGetComponent(out PlayableDirector director))
            {
                director.Pause();
            }
            else
            {
                obj.SetActive(false);
            }
        }

        // Set the victory state animation to loop while the game is paused
        if (playerAnimator != null)
        {
            playerAnimator.SetBool("IsVictoryLooping", true);
        }
    }

    public void UnpauseGame()
    {
        foreach (GameObject obj in objectsToPause)
        {
            if (obj.TryGetComponent(out PlayableDirector director))
            {
                director.Play();
            }
            else
            {
                obj.SetActive(true);
            }
        }

        // Check if both weapons are picked up, then transition to the thriller state
        if (hasWeaponInLeftHand && hasWeaponInRightHand)
        {
            if (playerAnimator != null)
            {
                playerAnimator.SetBool("IsVictoryLooping", false);  // Stop looping the victory state
                playerAnimator.SetTrigger("SwitchToThrillerState");  // Trigger the thriller state animation
            }
        }
    }

    // Methods to handle when the player picks up weapons
    public void SetWeaponInLeftHand(bool isPickedUp)
    {
        hasWeaponInLeftHand = isPickedUp;
        CheckForWeaponPickup();
    }

    public void SetWeaponInRightHand(bool isPickedUp)
    {
        hasWeaponInRightHand = isPickedUp;
        CheckForWeaponPickup();
    }

    private void CheckForWeaponPickup()
    {
        // If both weapons are picked up, unpause the game and switch animation state
        if (hasWeaponInLeftHand && hasWeaponInRightHand)
        {
            UnpauseGame();
        }
    }
}
