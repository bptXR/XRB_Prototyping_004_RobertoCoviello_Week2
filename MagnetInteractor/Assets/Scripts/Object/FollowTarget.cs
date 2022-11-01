using System;
using Line;
using UnityEngine;

namespace Object
{
    public class FollowTarget : MonoBehaviour
    {
        [SerializeField] private Transform targetTransform;
        [SerializeField] private Rigidbody rigidbody;
        [SerializeField] private float speed = 0.6f;
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
            //rigidbody.useGravity = false;
        }

        private void FixedUpdate()
        {
            float distance = Vector3.Distance(targetTransform.position, transform.position);

            if (distance >= _mass)
            {
                _canLift = true;
            }

            if (!_canLift) return;
            //transform.position =
            //Vector3.MoveTowards(transform.position, targetTransform.position, (speed + distance) * Time.deltaTime)
            rigidbody.MovePosition(Vector3.MoveTowards(transform.position, targetTransform.position,
                (speed + distance) * Time.fixedDeltaTime));
        }

        private void OnDisable()
        {
            curveRenderer.enabled = false;
            lineRenderer.enabled = false;
            rigidbody.isKinematic = false;
            //rigidbody.useGravity = true;
            //rigidbody.AddForce(transform.up * _mass);
        }
    }
}