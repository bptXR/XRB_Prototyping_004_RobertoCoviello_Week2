using System;
using Object;
using UnityEngine;

namespace Bullet
{
    public class MagnetBullet : MonoBehaviour
    {
        [SerializeField] private float duration = 3;

        private GameObject _targetPoint;
        private Transform _targetTransform;

        private void Awake()
        {
            _targetPoint = GameObject.FindGameObjectWithTag("TargetPoint");
            _targetTransform = _targetPoint.transform;
            Destroy(gameObject, duration);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (!collision.gameObject.CompareTag("MagneticObject")) return;
            collision.gameObject.GetComponent<FollowTarget>().enabled = true;
            var collisionPosition = collision.gameObject.transform.position;

            _targetTransform.position = new Vector3(_targetTransform.position.x, _targetTransform.position.y, collisionPosition.z);

            Destroy(gameObject);
        }
    }
}