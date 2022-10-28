using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class MultiInteractable : XRBaseInteractable
{
    [SerializeField] private Material material;

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        
        if (HasMultipleInteractors())
            material.color = Color.cyan;
    }

    private bool HasMultipleInteractors()
    {
        return interactorsSelecting.Count > 1;
    }
}
