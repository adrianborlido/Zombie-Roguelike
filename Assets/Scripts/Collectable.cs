using UnityEngine;

public class Collectable: Collidable {

    protected bool collected;

    protected override void OnCollide(Collider2D collider) {
        if(collider.CompareTag(Constants.TAG_PLAYER))
            OnCollect();
    }

    protected virtual void OnCollect() {
        collected = true;
    }
}