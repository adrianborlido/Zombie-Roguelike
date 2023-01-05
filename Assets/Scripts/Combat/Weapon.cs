using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon: Collidable {

    // TODO: Make this props virtual to override them on different weapons
    // Damage structure
    public int damagePoint = 1;
    public float pushForce = 2.0f;

    // Upgrade
    public int weaponLevel = 0;
    private SpriteRenderer spriteRenderer;

    // Swing
    private float cooldown = 0.5f;
    private float lastSwing;

    protected override void Start() {
        base.Start();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected override void Update() {
        base.Update();
        if(Input.GetKeyDown(KeyCode.Space) && Time.time - lastSwing > cooldown) {
            lastSwing = Time.time;
            Swing();
        }
    }

    protected override void OnCollide(Collider2D collider) {
        if(collider.tag == Constants.TAG_ENEMY) {
            Damage dmg = new Damage() {
                damageAmount = damagePoint,
                origin = transform.position,
                pushForce = pushForce
            };
            collider.SendMessage("ReceiveDamage", dmg);
        }
    }

    private void Swing() {

    }
}
