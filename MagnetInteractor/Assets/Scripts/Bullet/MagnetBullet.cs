using System;
using Object;
using UnityEngine;

namespace Bullet
{
    public class MagnetBullet : MonoBehaviour
    {
        [SerializeField] private Transform targetTransform;
        [SerializeField] private Transform magnetTransform;

        private FollowTarget _magneticObject;
        public static Action<FollowTarget> OnFollowTargetGet;

        private void OnCollisionEnter(Collision collision)
        {
            if (!collision.gameObject.CompareTag("MagneticObject")) return;
            _magneticObject = collision.gameObject.GetComponent<FollowTarget>();
            _magneticObject.enabled = true;

            OnFollowTargetGet?.Invoke(_magneticObject);

            float distance = Vector3.Distance(_magneticObject.transform.position, magnetTransform.position);

            targetTransform.localPosition = new Vector3(0, 0, distance);

            gameObject.SetActive(false);
        }
    }
}