using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; 

namespace MVP
{
    public class PlayerMovementController : MonoBehaviour
    {
        [SerializeField] Transform _shape;
        [SerializeField] CharacterController _characterController;
        // Start is called before the first frame update
        [SerializeField] private float moveSpeed = 5f; // Movement speed
        [SerializeField] private float jumpForce = 5f; // Jump force 

        private Vector3 moveDirection;
        private bool isJumping = false;

        public CharacterController CharacterController { get => _characterController; set => _characterController = value; }

        private void Awake()
        {
            CharacterController = GetComponent<CharacterController>();
        }

        private void Update()
        {
            // Get input axes
            float moveX = GameInput.CurrentGame.Vertical1;
            float moveZ = GameInput.CurrentGame.Horizontal1;

            // Calculate movement direction based on input
            moveDirection = Camera.main.gameObject.transform.TransformDirection(new Vector3(moveZ, 0f, moveX) * moveSpeed);
            _shape.LookAt(moveDirection);

            _shape.localEulerAngles = new Vector3(0, _shape.localEulerAngles.y, 0);

            // Check if the character is on the ground and the Jump button is pressed
            // if (_characterController.isGrounded)
            // {
            //   isJumping = Input.GetButtonDown("Jump");
            // }

            // Apply gravity
            moveDirection.y += Physics.gravity.y;

            // Jump if the Jump button is pressed
            if (isJumping)
            {
                moveDirection.y = jumpForce;
                isJumping = false;
            }

            // Move the character
            CharacterController.SimpleMove(moveDirection);
        }
    }
}