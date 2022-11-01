using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Target
{
    public class TargetMover : MonoBehaviour
    {
        [SerializeField] private InputActionReference rightMove;
        [SerializeField] private InputActionReference leftMove;
        [SerializeField] private Transform targetTransform;
        [SerializeField] private float movementSpeed = 0.6f;

        private bool _isMoving;

        private void Update()
        {
            if (!_isMoving) return;
            Vector2 valueRight = rightMove.action.ReadValue<Vector2>();
            Vector2 valueLeft = leftMove.action.ReadValue<Vector2>();
            Vector2 moveProduct = valueLeft + valueRight;
        
            Vector3 position = targetTransform.localPosition;
            position += new Vector3(0, 0, movementSpeed * moveProduct.y);
            targetTransform.localPosition = position;
        }

        private void OnEnable()
        {
            rightMove.action.performed += MoveActivate;
            rightMove.action.canceled += MoveCancel;

            leftMove.action.performed += MoveActivate;
            leftMove.action.canceled += MoveCancel;
        }

        private void MoveActivate(InputAction.CallbackContext obj) => _isMoving = true;
        private void MoveCancel(InputAction.CallbackContext obj) => _isMoving = false;

        private void OnDisable()
        {
            rightMove.action.performed -= MoveActivate;
            rightMove.action.canceled -= MoveCancel;

            leftMove.action.performed -= MoveActivate;
            leftMove.action.canceled -= MoveCancel;
        }
    }
}