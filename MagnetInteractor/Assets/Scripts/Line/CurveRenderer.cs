using System.Collections.Generic;
using UnityEngine;

namespace Line
{
    public class CurveRenderer : MonoBehaviour
    {
        [SerializeField] private Transform pointOne;
        [SerializeField] private Transform pointTwo;
        [SerializeField] private Transform pointThree;
        [SerializeField] private LineRenderer lineRenderer;
        [SerializeField] private float vertexCount = 12;

        private void Update()
        {
            var pointList = new List<Vector3>();

            for (float ratio = 0; ratio <= 1; ratio += 1 / vertexCount)
            {
                var tangentOne = Vector3.Lerp(pointOne.position, pointTwo.position, ratio);
                var tangentTwo = Vector3.Lerp(pointTwo.position, pointThree.position, ratio);
                var curve = Vector3.Lerp(tangentOne, tangentTwo, ratio);

                pointList.Add(curve);
            }

            lineRenderer.positionCount = pointList.Count;
            lineRenderer.SetPositions(pointList.ToArray());
        }
    }
}