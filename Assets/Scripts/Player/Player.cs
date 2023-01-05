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
        float x = Input.GetAxisRaw(Constants.AXIS_HORIZONTAL);
        float y = Input.GetAxisRaw(Constants.AXIS_VERTICAL);
        moveDelta = new Vector2(x, y);

        if(moveDelta.x > 0) {
            transform.localScale = Vector3.one;
        } else if(moveDelta.x < 0) {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        hit = GetRaycastHit(0, moveDelta.y, moveDelta.y);
        if(hit.collider == null) {
            transform.Translate(0, moveDelta.y * moveSpeed * Time.deltaTime, 0);
        }

        hit = GetRaycastHit(moveDelta.x, 0, moveDelta.x);
        if(hit.collider == null) {
            transform.Translate(moveDelta.x * moveSpeed * Time.deltaTime, 0, 0);
        }
    }

    private RaycastHit2D GetRaycastHit(float vector2X, float vector2Y, float moveDelta) {
        return Physics2D.BoxCast(
                    transform.position,
                    boxCollider.size,
                    0,
                    new Vector2(vector2X, vector2Y),
                    Mathf.Abs(moveDelta * moveSpeed * Time.deltaTime),
                    LayerMask.GetMask(Constants.LAYER_UNIT, Constants.LAYER_BLOCKING));
    }
}
