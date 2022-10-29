using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Target
{
    public class TargetMover : MonoBehaviour
    {
        [SerializeField] private InputActionReference rightMove;
        [SerializeField] private InputActionReference rightRotate;
        [SerializeField] private InputActionReference leftMove;
        [SerializeField] private InputActionReference leftRotate;
        [SerializeField] private Transform objectTransform;
        [SerializeField] private float movementSpeed = 0.15f;
        [SerializeField] private float rotationSpeed;

        public bool isMoving;
        public bool isRotating;

        private void Update()
        {
            if (isMoving)
            {
                Vector2 valueRight = rightMove.action.ReadValue<Vector2>();
                Vector2 valueLeft = leftMove.action.ReadValue<Vector2>();
                Vector2 moveProduct = valueLeft + valueRight;

                var position = objectTransform.position;
                position += new Vector3(0, 0, movementSpeed * moveProduct.y);
                objectTransform.position = position;
            }

            if (isRotating)
            {
                Vector2 valueRight = rightRotate.action.ReadValue<Vector2>();
                Vector2 valueLeft = leftRotate.action.ReadValue<Vector2>();
                Vector2 rotationProduct = valueLeft + valueRight;

                var rotation = objectTransform.eulerAngles;
                rotation += new Vector3(rotationProduct.x, 0, 0);

                transform.Rotate(rotation, rotationSpeed * Time.deltaTime);
            }
        }

        private void OnEnable()
        {
            rightMove.action.performed += MoveActivate;
            rightMove.action.canceled += MoveCancel;

            leftMove.action.performed += MoveActivate;
            leftMove.action.canceled += MoveCancel;

            rightRotate.action.performed += RotateActivate;
            rightRotate.action.canceled += RotateCancel;

            leftRotate.action.performed += RotateActivate;
            leftRotate.action.canceled += RotateCancel;
        }

        private void MoveActivate(InputAction.CallbackContext obj) => isMoving = true;
        private void MoveCancel(InputAction.CallbackContext obj) => isMoving = false;
        private void RotateActivate(InputAction.CallbackContext obj) => isRotating = true;
        private void RotateCancel(InputAction.CallbackContext obj) => isRotating = false;

        private void OnDisable()
        {
            rightMove.action.performed -= MoveActivate;
            rightMove.action.canceled -= MoveCancel;

            leftMove.action.performed -= MoveActivate;
            leftMove.action.canceled -= MoveCancel;

            rightRotate.action.performed -= RotateActivate;
            rightRotate.action.canceled -= RotateCancel;

            leftRotate.action.performed -= RotateActivate;
            leftRotate.action.canceled -= RotateCancel;
        }
    }
}