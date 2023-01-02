using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController: MonoBehaviour {

    [SerializeField] float _Speed;
    Vector2 _Movement;
    Rigidbody2D _Rigidbody;

    private void Awake() {
        _Rigidbody = GetComponent<Rigidbody2D>();
    }
    private void OnMovement(InputValue value) {
        _Movement = value.Get<Vector2>();
    }

    private void FixedUpdate() {
        _Rigidbody.velocity = _Movement * _Speed;
    }
}
