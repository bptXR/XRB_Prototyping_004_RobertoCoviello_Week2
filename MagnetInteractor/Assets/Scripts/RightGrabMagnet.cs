using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RightGrabMagnet : XRRayInteractor
{
    [SerializeField] private XRRayInteractor leftRayInteractor;
    
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        leftRayInteractor.enabled = false;
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);
        leftRayInteractor.enabled = true;
    }
}
