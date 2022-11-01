using System;
using Object;
using UnityEngine;

namespace Bullet
{
    public class MagnetBullet : MonoBehaviour
    {
        [SerializeField] private float duration = 3;
        [SerializeField] private Transform targetTransform;
        
        private FollowTarget _magneticObject;
        public static Action<FollowTarget> onFollowTargetGet;

        private void OnCollisionEnter(Collision collision)
        {
            if (!collision.gameObject.CompareTag("MagneticObject")) return;
            _magneticObject = collision.gameObject.GetComponent<FollowTarget>();
            _magneticObject.enabled = true;
            
            onFollowTargetGet?.Invoke(_magneticObject);
            
            Vector3 collisionPosition = collision.gameObject.transform.position;
            Vector3 position = targetTransform.position;
            position = new Vector3(position.x, position.y, collisionPosition.z);
            targetTransform.position = position;
            
            gameObject.SetActive(false);
        }
    }
}