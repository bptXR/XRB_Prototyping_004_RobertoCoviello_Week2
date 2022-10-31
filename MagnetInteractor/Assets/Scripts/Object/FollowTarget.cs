using System;
using Line;
using UnityEngine;

namespace Object
{
    public class FollowTarget : MonoBehaviour
    {
        [SerializeField] private Transform targetTransform;
        [SerializeField] private Rigidbody rigidbody;
        [SerializeField] private float speed = 0.5f;
        [SerializeField] private CurveRenderer curveRenderer;
        [SerializeField] private LineRenderer lineRenderer;
        

        private float _mass;
        private bool _canLift;

        private void Awake()
        {
            _mass = rigidbody.mass;
        }

        private void OnEnable()
        {
            curveRenderer.enabled = true;
            lineRenderer.enabled = true;
            rigidbody.isKinematic = true;
        }

        private void Update()
        {
            float distance = Vector3.Distance(targetTransform.position, transform.position);

            if (distance >= _mass)
            {
                _canLift = true;
            }

            if (!_canLift) return;
            transform.position =
                Vector3.MoveTowards(transform.position, targetTransform.position, (speed + distance) * Time.deltaTime);
        }

        private void OnDisable()
        {
            curveRenderer.enabled = false;
            lineRenderer.enabled = false;
            rigidbody.isKinematic = false;
        }
    }
}