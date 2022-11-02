using System;
using Object;
using UnityEngine;

namespace Bullet
{
    public class MagnetBullet : MonoBehaviour
    {
        [SerializeField] private Transform targetTransform;

        private FollowTarget _magneticObject;
        public static Action<FollowTarget> OnFollowTargetGet;

        private void OnCollisionEnter(Collision collision)
        {
            if (!collision.gameObject.CompareTag("MagneticObject")) return;
            _magneticObject = collision.gameObject.GetComponent<FollowTarget>();
            _magneticObject.enabled = true;

            OnFollowTargetGet?.Invoke(_magneticObject);

            targetTransform.position = _magneticObject.transform.position;

            gameObject.SetActive(false);
        }
    }
}