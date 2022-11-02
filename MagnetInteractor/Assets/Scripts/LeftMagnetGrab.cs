using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LeftMagnetGrab : XRRayInteractor
{
    [SerializeField] private XRRayInteractor rightRayInteractor;
    
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        rightRayInteractor.enabled = false;
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);
        rightRayInteractor.enabled = true;
    }
}
