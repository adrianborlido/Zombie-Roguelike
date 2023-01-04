using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player: MonoBehaviour {

    private BoxCollider2D boxCollider;
    private Vector3 moveDelta;
    private float moveSpeed = 4;
    private RaycastHit2D hit;

    // Start is called before the first frame update
    void Start() {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate() {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        moveDelta = new Vector2(x, y);

        if(moveDelta.x > 0) {
            transform.localScale = Vector3.one;
        } else if(moveDelta.x < 0) {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        hit = Physics2D.BoxCast(
            transform.position,
            boxCollider.size,
            0,
            new Vector2(0, moveDelta.y),
            Mathf.Abs(moveDelta.y * moveSpeed * Time.deltaTime),
            LayerMask.GetMask("Unit", "BlockingLayer"));
        if(hit.collider == null) {
            transform.Translate(0, moveDelta.y * moveSpeed * Time.deltaTime, 0);
        }

        hit = Physics2D.BoxCast(
            transform.position,
            boxCollider.size,
            0,
            new Vector2(moveDelta.x, 0),
            Mathf.Abs(moveDelta.x * moveSpeed * Time.deltaTime),
            LayerMask.GetMask("Unit", "BlockingLayer"));
        if(hit.collider == null) {
            transform.Translate(moveDelta.x * moveSpeed * Time.deltaTime, 0, 0);
        }
    }
}
