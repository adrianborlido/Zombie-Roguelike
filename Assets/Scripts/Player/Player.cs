using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player: MonoBehaviour {

    [SerializeField] int health = 4;
    [SerializeField] int damage = 1;

    // Movement
    [SerializeField] float _Speed = 4;
    [SerializeField] Camera _Camera;
    PlayerInput _Input;
    Vector2 _Movement;
    Vector2 _MousePosition;
    Rigidbody2D _Rigidbody;

    private void Awake() {
        _Input = new PlayerInput();
        _Rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable() {
        _Input.Enable();
        _Input.Gameplay.Movement.performed += OnMovement;
        _Input.Gameplay.Movement.canceled += OnMovement;
        _Input.Gameplay.MousePosition.performed += OnMousePosition;
    }

    private void OnDisable() {
        _Input.Disable();
    }

    private void OnMovement(InputAction.CallbackContext context) {
        _Movement = context.ReadValue<Vector2>();
    }
    private void OnMousePosition(InputAction.CallbackContext context) {
        _MousePosition = _Camera.ScreenToWorldPoint(context.ReadValue<Vector2>());
    }

    private void FixedUpdate() {
        _Rigidbody.velocity = _Movement * _Speed;

        // If you want to keep accelarating at the end of the movement, use this instead
        // _Rigidbody.AddForce(_Movement * _Speed);

        Vector2 facingDirection = _MousePosition - _Rigidbody.position;
        float angle = Mathf.Atan2(facingDirection.y, facingDirection.x) * Mathf.Rad2Deg;
        _Rigidbody.MoveRotation(angle);
    }

    private void CheckIfGameOver() {
        if(health <= 0) {
            // TODO: - Trigger player death animation
            // Finish game
        }
    }

    public void LoseHealth(int loss) {
        //TODO: - Trigger player hit animation
        health -= loss;
        CheckIfGameOver();
    }
}
