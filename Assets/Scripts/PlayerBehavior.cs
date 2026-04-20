using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehavior : MonoBehaviour
{
    public float thrustPower = 25f;
    public float maxSpeed = 15f;
    public float drag = 0.98f;

    public GameObject fire;

    private Rigidbody2D rb;
    private bool holding;

    private Camera cam;
    private float minY;
    private float maxY;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;

        if (fire != null)
            fire.SetActive(false);
    }

    void Update()
    {
        holding = Keyboard.current != null && Keyboard.current.spaceKey.isPressed;

        if (fire != null)
            fire.SetActive(holding);

        CalculateBounds();
    }

    void FixedUpdate()
    {
        if (holding)
        {
            rb.AddForce(Vector2.up * thrustPower);
        }

        rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxSpeed);
        rb.velocity *= drag;

        ClampPosition();
    }

    void CalculateBounds()
    {
        float camHeight = cam.orthographicSize;

        minY = cam.transform.position.y - camHeight;
        maxY = cam.transform.position.y + camHeight;
    }

    void ClampPosition()
    {
        Vector2 pos = rb.position;

        if (pos.y > maxY)
        {
            pos.y = maxY;
            rb.velocity = new Vector2(rb.velocity.x, 0);
        }

        if (pos.y < minY)
        {
            pos.y = minY;
            rb.velocity = new Vector2(rb.velocity.x, 0);
        }

        rb.position = pos;
    }
}