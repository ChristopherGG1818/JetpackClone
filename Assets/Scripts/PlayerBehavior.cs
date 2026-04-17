using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehavior : MonoBehaviour
{
    public float thrustPower = 25f;
    public float maxSpeed = 15f;
    public float drag = 0.98f;

    private Rigidbody2D rb;
    private bool holding;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        holding = Keyboard.current != null && Keyboard.current.spaceKey.isPressed;
    }

    void FixedUpdate()
    {
        if (holding)
        {
            rb.AddForce(Vector2.up * thrustPower);
        }

        // soft speed limit (prevents infinite acceleration)
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxSpeed);

        // optional: light drag to simulate space resistance
        rb.velocity *= drag;
    }
}