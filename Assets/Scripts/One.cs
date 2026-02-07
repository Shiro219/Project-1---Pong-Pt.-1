using UnityEngine;
using UnityEngine.InputSystem;
public class One : MonoBehaviour
{
    public Key upKey;
    public Key downKey;
    public float speed = 5f;
    private Rigidbody rb;

    void Start() { rb = GetComponent<Rigidbody>(); }

    void Update()
    {
        float moveZ = 0f;
        if (Keyboard.current[upKey].isPressed) moveZ = 1f;
        if (Keyboard.current[downKey].isPressed) moveZ = -1f;
        rb.linearVelocity = new Vector3(0f, rb.linearVelocity.y, moveZ * speed);
    }
}
