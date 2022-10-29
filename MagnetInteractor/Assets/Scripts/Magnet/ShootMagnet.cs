using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace Magnet
{
    public class ShootMagnet : XRGrabInteractable
    {
        [SerializeField] private Transform bulletSpawnPoint;
        [SerializeField] private GameObject magnetBulletPrefab;
        [SerializeField] private float bulletSpeed = 10;

        protected override void OnActivated(ActivateEventArgs args)
        {
            base.OnActivated(args);
            Shoot();
        }

        private void Shoot()
        {
            var bullet = Instantiate(magnetBulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
        }
    }
}