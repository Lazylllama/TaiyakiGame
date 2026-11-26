using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour {
	[SerializeField]         Transform playerCamera;
	[SerializeField] private float     speed;
	[SerializeField] private float     sprintSpeed;

	private InputActionReference move;
	private InputActionReference sprint;
	private CharacterController  characterController;
	private float                yVelocity;

	private void Awake() {
		characterController = GetComponent<CharacterController>();
		Cursor.lockState    = CursorLockMode.Locked;
	}

	private void Start() {
		move   = InputHandler.Instance.moveAction;
		sprint = InputHandler.Instance.sprintAction;
	}

	private void Update() {
		var input       = move.action.ReadValue<Vector2>();
		var isSprinting = sprint.action.IsPressed();

		var forward = playerCamera.forward;
		forward.y = 0;
		forward.Normalize();

		var right = playerCamera.right;
		right.y = 0;
		right.Normalize();

		var currentSpeed = isSprinting ? sprintSpeed : speed;

		yVelocity = characterController.isGrounded ? -1f : yVelocity + Physics.gravity.y * Time.deltaTime;
		characterController.Move(((forward * input.y + right * input.x) * currentSpeed + Vector3.up * yVelocity) *
		                         Time.deltaTime);
	}
}