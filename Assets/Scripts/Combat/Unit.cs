using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit: MonoBehaviour {
    // Public fields
    public int hitpoint = 10;
    public int maxHitpoint = 10;
    public float pushRecoverySpeed = 0.2f;

    // Immunity
    protected float immuneTime = 1.0f;
    protected float lastImmune;


    // Push
    protected Vector3 pushDirection;

    protected virtual void ReceiveDamage(Damage dmg) {
        if(Time.time - lastImmune > immuneTime) {
            lastImmune = Time.time;
            hitpoint -= dmg.damageAmount;
            pushDirection = (transform.position - dmg.origin).normalized * dmg.pushForce;

            GameManager.instance.ShowText(dmg.damageAmount.ToString(), 20, Color.red, transform.position, Vector3.zero, 0.5f);

            if(hitpoint <= 0) {
                hitpoint = 0;
                Death();
            }
        }
    }

    protected virtual void Death() {
    
    }

}
