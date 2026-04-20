using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehavior : MonoBehaviour
{
    public float thrustPower = 25f;
    public float maxSpeed = 15f;
    public float drag = 0.98f;

    public GameObject fire; //Fire object here

    private Rigidbody2D rb;
    private bool holding;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (fire != null)
            fire.SetActive(false); // start with no fire
    }

    void Update()
    {
        holding = Keyboard.current != null && Keyboard.current.spaceKey.isPressed;

        // fire
        if (fire != null)
            fire.SetActive(holding);
    }

    void FixedUpdate()
    {
        if (holding)
        {
            rb.AddForce(Vector2.up * thrustPower);
        }

        // soft speed limit
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxSpeed);

        // light drag
        rb.velocity *= drag;
    }
}