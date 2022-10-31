using Object;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace Magnet
{
    public class MagnetRayInteractor : XRRayInteractor
    {
        protected override void OnHoverEntered(HoverEnterEventArgs args)
        {
            base.OnHoverEntered(args);
            if (args.interactableObject is MagneticObject magneticObject)
            {
                Destroy(magneticObject);
            }
        }
    }
}
