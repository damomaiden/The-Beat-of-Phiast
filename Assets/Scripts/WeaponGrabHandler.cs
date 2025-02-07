using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class WeaponGrabHandler : MonoBehaviour
{
    public XRGrabInteractable grabInteractable;
    public Rigidbody rb;
    public static int weaponsHeld = 0;
    public static GamePauseHandler gamePauseHandler;

    private void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        rb = GetComponent<Rigidbody>();

        if (gamePauseHandler == null)
        {
            gamePauseHandler = FindAnyObjectByType<GamePauseHandler>();

        }
    }

    public void OnEnable()
    {
        grabInteractable.selectEntered.AddListener(OnGrabbed);
    }

    public void OnDisable()
    {
        grabInteractable.selectEntered.RemoveListener(OnGrabbed);
    }

    public void OnGrabbed(SelectEnterEventArgs args)
    {
        XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();

        // Prevent dropping
        grabInteractable.throwOnDetach = false;

        // Ensure the player cannot release the weapon
        grabInteractable.selectExited.AddListener((args) =>
        {
            grabInteractable.interactionManager.SelectEnter(args.interactorObject, grabInteractable);
        });

        //public void OnGrabbed(SelectEnterEventArgs args)
        //{
        //    XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();

        //    // Prevent dropping
        //    grabInteractable.throwOnDetach = false;

        //    // Disable releasing the weapon while keeping normal movement
        //    grabInteractable.interactionLayers = InteractionLayerMask.None;
        //}

    }

}


