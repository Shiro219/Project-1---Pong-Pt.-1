using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float moveZ = 0f;

        if (Keyboard.current.upArrowKey.isPressed)
            moveZ = 1f;
        else if (Keyboard.current.downArrowKey.isPressed)
            moveZ = -1f;

        rb.linearVelocity = new Vector3(
            0f,
            rb.linearVelocity.y,
            moveZ * speed
        );
    }
}