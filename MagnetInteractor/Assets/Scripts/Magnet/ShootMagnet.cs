using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.XR.Interaction.Toolkit;

namespace Magnet
{
    public class ShootMagnet : XRGrabInteractable
    {
        [SerializeField] private Transform bulletSpawnPoint;
        [SerializeField] private GameObject magnetBulletPrefab;
        [SerializeField] private float bulletSpeed = 10;
        [SerializeField] private MagnetRayInteractor magnetRayInteractor;
        [SerializeField] private UniversalRendererData renderSettings;
        
        public static Action<bool> onBeingGrabbed;

        protected override void OnActivated(ActivateEventArgs args)
        {
            base.OnActivated(args);
            Shoot();
        }

        protected override void OnSelectEntered(SelectEnterEventArgs args)
        {
            base.OnSelectEntered(args);
            magnetRayInteractor.enabled = true;
            renderSettings.rendererFeatures[0].SetActive(true);
            renderSettings.rendererFeatures[1].SetActive(true);
            renderSettings.rendererFeatures[2].SetActive(true);
        }

        protected override void OnSelectExited(SelectExitEventArgs args)
        {
            base.OnSelectExited(args);
            magnetRayInteractor.enabled = false;
            renderSettings.rendererFeatures[0].SetActive(false);
            renderSettings.rendererFeatures[1].SetActive(false);
            renderSettings.rendererFeatures[2].SetActive(false);
        }

        protected override void OnActivate(XRBaseInteractor interactor)
        {
            base.OnActivate(interactor);
            renderSettings.rendererFeatures[0].SetActive(false);
            renderSettings.rendererFeatures[1].SetActive(false);
            renderSettings.rendererFeatures[2].SetActive(false);
        }

        private void Shoot()
        {
            var bullet = Instantiate(magnetBulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
        }
    }
}