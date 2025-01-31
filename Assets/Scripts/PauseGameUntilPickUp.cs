using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class GamePauseUntilWeaponsPicked : MonoBehaviour
{
    [SerializeField] private XRGrabInteractable axe;
    [SerializeField] private XRGrabInteractable hammer;

    private bool axePickedUp = false;
    private bool hammerPickedUp = false;

    private void Start()
    {
        // Pause the game at the start
        Time.timeScale = 0f;

        // Subscribe to the grab events
        axe.selectEntered.AddListener(OnAxePickedUp);
        hammer.selectEntered.AddListener(OnHammerPickedUp);
    }

    private void OnAxePickedUp(SelectEnterEventArgs args)
    {
        axePickedUp = true;
        CheckWeaponsPicked();
    }

    private void OnHammerPickedUp(SelectEnterEventArgs args)
    {
        hammerPickedUp = true;
        CheckWeaponsPicked();
    }

    private void CheckWeaponsPicked()
    {
        if (axePickedUp && hammerPickedUp)
        {
            Time.timeScale = 1f; // Resume the game
            Debug.Log("Both weapons picked up. Game unpaused.");
        }
    }

    private void OnDestroy()
    {
        // Unsubscribe to avoid memory leaks
        axe.selectEntered.RemoveListener(OnAxePickedUp);
        hammer.selectEntered.RemoveListener(OnHammerPickedUp);
    }
}
