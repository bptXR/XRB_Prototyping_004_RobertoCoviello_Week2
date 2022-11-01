using System.Collections.Generic;
using Bullet;
using Object;
using UnityEngine;

namespace Line
{
    public class CurveRenderer : MonoBehaviour
    {
        [SerializeField] private Transform magnetPoint;
        [SerializeField] private Transform targetPoint;
        [SerializeField] private LineRenderer lineRenderer;
        [SerializeField] private float vertexCount = 12;

        private FollowTarget _magneticObject;
        
        private void OnEnable()
        {
            MagnetBullet.onFollowTargetGet += SetMagneticObject;
        }

        private void SetMagneticObject(FollowTarget obj) => _magneticObject = obj;

        private void Update()
        {
            var pointList = new List<Vector3>();

            for (float i = 0; i <= 1; i += 1 / vertexCount)
            {
                var tangentOne = Vector3.Lerp(magnetPoint.position, targetPoint.position, i);
                var tangentTwo = Vector3.Lerp(targetPoint.position, _magneticObject.transform.position, i);
                var curve = Vector3.Lerp(tangentOne, tangentTwo, i);

                pointList.Add(curve);
            }

            lineRenderer.positionCount = pointList.Count;
            lineRenderer.SetPositions(pointList.ToArray());
        }
    }
}