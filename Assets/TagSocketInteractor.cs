using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

// This script extends the standard XRSocketInteractor
public class TagSocketInteractor : XRSocketInteractor
{
    [Header("Validation Settings")]
    [Tooltip("The tag the object must have to be accepted by this socket.")]
    public string targetTag = "KeyObject";

    // This function is called automatically by Unity before accepting an object
    public override bool CanSelect(IXRSelectInteractable interactable)
    {
        // 1. Check the standard rules (distance, layer, etc.)
        bool isStandardValid = base.CanSelect(interactable);

        // 2. If standard rules pass, check if the object has the correct TAG
        if (isStandardValid && interactable.transform.CompareTag(targetTag))
        {
            return true;
        }

        // Otherwise, reject it
        return false;
    }

    // Optional: Also override Hover to prevent the "preview" mesh from appearing for wrong objects
    public override bool CanHover(IXRHoverInteractable interactable)
    {
        return base.CanHover(interactable) && interactable.transform.CompareTag(targetTag);
    }
}