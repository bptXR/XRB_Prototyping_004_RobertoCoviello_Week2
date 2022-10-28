using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DoubleXRGrabInteractable : XRGrabInteractable
{
    protected override void Awake()
    {
        base.Awake();
        selectMode = InteractableSelectMode.Multiple;
    }

    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {
        if (interactorsSelecting.Count == 1)
        {
            base.ProcessInteractable(updatePhase);
        }
        else if (interactorsSelecting.Count == 2 && updatePhase == XRInteractionUpdateOrder.UpdatePhase.Fixed)
        {
            CalculateMovement();
        }
    }

    private void CalculateMovement()
    {
        Transform firstInteractorTransform = interactorsSelecting[0].transform;
        Transform secondInteractorTransform = interactorsSelecting[1].transform;


        
        //transform.SetPositionAndRotation(targetPosition, targetRotation);
    }

    protected override void Grab()
    {
        if (interactorsSelecting.Count != 1) return;
        base.Grab();
    }

    protected override void Drop()
    {
        if (isSelected) return;
        base.Drop();
    }
}