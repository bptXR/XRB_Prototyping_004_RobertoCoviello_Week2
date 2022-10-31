using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace Magnet
{
    public class ShootMagnet : XRGrabInteractable
    {
        [SerializeField] private Transform bulletSpawnPoint;
        [SerializeField] private GameObject magnetBulletPrefab;
        [SerializeField] private float bulletSpeed = 10;
        [SerializeField] private MagnetRayInteractor magnetRayInteractor;
        
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
        }

        protected override void OnSelectExited(SelectExitEventArgs args)
        {
            base.OnSelectExited(args);
            magnetRayInteractor.enabled = false;
        }

        private void Shoot()
        {
            var bullet = Instantiate(magnetBulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
        }
    }
}