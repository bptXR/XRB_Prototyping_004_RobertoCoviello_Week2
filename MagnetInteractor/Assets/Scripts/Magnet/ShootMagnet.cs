using System;
using System.Collections;
using System.Linq;
using Object;
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
        [SerializeField] private FollowTarget followTarget;

        private bool _isWaiting;
        private GameObject _bullet;
        
        protected override void OnActivated(ActivateEventArgs args)
        {
            base.OnActivated(args);
            StartCoroutine(Shoot());
        }

        protected override void OnSelectEntered(SelectEnterEventArgs args)
        {
            base.OnSelectEntered(args);
            magnetRayInteractor.enabled = true;
            RenderSettings(true);
        }

        protected override void OnSelectExited(SelectExitEventArgs args)
        {
            base.OnSelectExited(args);
            magnetRayInteractor.enabled = false;
            RenderSettings(false);
        }

        protected override void OnActivate(XRBaseInteractor interactor)
        {
            base.OnActivate(interactor);
            RenderSettings(false);
            magnetRayInteractor.enabled = false;
        }

        protected override void OnDeactivated(DeactivateEventArgs args)
        {
            base.OnDeactivated(args);
            RenderSettings(true);
            Destroy(_bullet);
            followTarget.enabled = false;
            magnetRayInteractor.enabled = true;
        }

        private IEnumerator Shoot()
        {
            if (_isWaiting) yield break;
            _bullet = Instantiate(magnetBulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            _bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
                
            _isWaiting = true;
            yield return new WaitForSeconds(3.1f);
            _isWaiting = false;
        }

        private void RenderSettings(bool enable)
        {
            renderSettings.rendererFeatures[0].SetActive(enable);
            renderSettings.rendererFeatures[1].SetActive(enable);
            renderSettings.rendererFeatures[2].SetActive(enable);
        }
    }
}