using System;
using System.Collections;
using System.Linq;
using Bullet;
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
        [SerializeField] private Transform magnetBulletPrefab;
        [SerializeField] private Rigidbody magnetBulletPrefabRigidbody;
        [SerializeField] private float bulletSpeed = 10;
        [SerializeField] private MagnetRayInteractor magnetRayInteractor;
        [SerializeField] private UniversalRendererData renderSettings;
        
        private FollowTarget _magneticObject;
        private bool _isWaiting;

        protected override void OnEnable()
        {
            base.OnEnable();
            MagnetBullet.OnFollowTargetGet += SetMagneticObject;
        }

        private void SetMagneticObject(FollowTarget obj) => _magneticObject = obj;

        protected override void OnActivated(ActivateEventArgs args)
        {
            base.OnActivated(args);
            StartCoroutine(Shoot());
            RenderSettings(false);
            magnetRayInteractor.enabled = false;
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

        protected override void OnDeactivated(DeactivateEventArgs args)
        {
            base.OnDeactivated(args);
            StopCoroutine(Shoot());
            RenderSettings(true);
            magnetBulletPrefab.gameObject.SetActive(false);
            _magneticObject.enabled = false;
            magnetRayInteractor.enabled = true;
        }

        private IEnumerator Shoot()
        {
            if (_isWaiting) yield break;
            magnetBulletPrefab.position = bulletSpawnPoint.position;
            magnetBulletPrefab.rotation = bulletSpawnPoint.rotation;
            magnetBulletPrefab.gameObject.SetActive(true);
            magnetBulletPrefabRigidbody.velocity = bulletSpawnPoint.forward * bulletSpeed;
                
            _isWaiting = true;
            yield return new WaitForSeconds(1f);
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