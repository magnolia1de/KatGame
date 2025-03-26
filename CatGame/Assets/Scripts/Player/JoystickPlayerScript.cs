using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickPlayerScript2D : MonoBehaviour
{
    public float speed = 5f;
    public VariableJoystick variableJoystick;
    public Rigidbody2D rb;

    private void FixedUpdate()
    {
        Vector2 direction = new Vector2(variableJoystick.Horizontal, 0f);
        rb.linearVelocity = direction * speed;
    }
}
