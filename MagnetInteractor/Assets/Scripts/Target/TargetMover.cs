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
        [SerializeField] private Transform magnetTransform;
        [SerializeField] private float movementSpeed = 0.15f;

        public bool isMoving;

        private void Update()
        {
            if (!isMoving) return;
            Vector2 valueRight = rightMove.action.ReadValue<Vector2>();
            Vector2 valueLeft = leftMove.action.ReadValue<Vector2>();
            Vector2 moveProduct = valueLeft + valueRight;

            var position = targetTransform.position;
            position += new Vector3(0, 0, movementSpeed * moveProduct.y);
            targetTransform.position = position;
        }

        private void OnEnable()
        {
            rightMove.action.performed += MoveActivate;
            rightMove.action.canceled += MoveCancel;

            leftMove.action.performed += MoveActivate;
            leftMove.action.canceled += MoveCancel;
        }

        private void MoveActivate(InputAction.CallbackContext obj) => isMoving = true;
        private void MoveCancel(InputAction.CallbackContext obj) => isMoving = false;

        private void OnDisable()
        {
            rightMove.action.performed -= MoveActivate;
            rightMove.action.canceled -= MoveCancel;

            leftMove.action.performed -= MoveActivate;
            leftMove.action.canceled -= MoveCancel;
        }
    }
}