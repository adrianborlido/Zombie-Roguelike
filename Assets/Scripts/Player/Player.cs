using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player: Mover {
    private void FixedUpdate() {
        float x = Input.GetAxisRaw(Constants.AXIS_HORIZONTAL);
        float y = Input.GetAxisRaw(Constants.AXIS_VERTICAL);

        UpdateMotor(new Vector3(x, y, 0));
    }
}
