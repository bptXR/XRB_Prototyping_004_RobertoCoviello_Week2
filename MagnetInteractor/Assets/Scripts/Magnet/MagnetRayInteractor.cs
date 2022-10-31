using System;
using UnityEngine;

namespace Magnet
{
    public class MagnetRayInteractor : MonoBehaviour
    {
        [SerializeField] private LayerMask layerMask;
        [SerializeField] private Material highlightMaterial;

        private MeshRenderer _meshRenderer;
        private Material _oldMaterial;
        private bool _highlightApplied;

        private void FixedUpdate()
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.localPosition, transform.TransformDirection(Vector3.forward), out hit,
                    100, layerMask))
            {
                if (_highlightApplied) return;
                _meshRenderer = hit.transform.gameObject.GetComponent<MeshRenderer>();
                _oldMaterial = _meshRenderer.material;
                _meshRenderer.material = highlightMaterial;
                _highlightApplied = true;
            }
            else
            {
                if (!_highlightApplied) return;
                DisableMeshRender();
                _highlightApplied = false;
            }
        }

        private void OnDisable()
        {
            if (_meshRenderer == null) return;
            DisableMeshRender();
        }

        private void DisableMeshRender()
        {
            _meshRenderer.material = _oldMaterial;
            _meshRenderer = null;
            _highlightApplied = false;
        }
    }
}