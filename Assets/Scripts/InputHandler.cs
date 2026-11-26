using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour {
	public static InputHandler Instance { get; private set; }

	[SerializeField] public InputActionReference moveAction;
	[SerializeField] public InputActionReference dropAction;
	[SerializeField] public InputActionReference pauseAction;
	[SerializeField] public InputActionReference sprintAction;
	[SerializeField] public InputActionReference interactAction;

	private void Awake() {
		if (Instance != null && Instance != this) {
			Destroy(this);
		} else {
			Instance = this;
		}

		moveAction.action.Enable();
		sprintAction.action.Enable();

		dropAction.action.Enable();
		dropAction.action.performed += OnDrop;

		pauseAction.action.Enable();
		pauseAction.action.performed += OnPause;

		interactAction.action.Enable();
		interactAction.action.performed += OnInteract;
	}

	private void OnDrop(InputAction.CallbackContext ctx) {
		if (ctx.performed) {
			Debug.Log($"{ctx.action.name} triggered");
		}
	}

	private void OnPause(InputAction.CallbackContext ctx) {
		if (ctx.performed) {
			Debug.Log($"{ctx.action.name} triggered");
		}
	}

	private void OnInteract(InputAction.CallbackContext ctx) {
		if (ctx.performed) {
			Debug.Log($"{ctx.action.name} triggered");
		}
	}
}