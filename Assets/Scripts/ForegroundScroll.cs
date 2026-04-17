using UnityEngine;

public class ForegroundScroll : MonoBehaviour
{
    public float speed = 5f;
    public float width = 20f; // IMPORTANT: match your sprite width

    void Update()
    {
        // move left
        transform.position += Vector3.left * speed * Time.deltaTime;

        // if off screen, move to the right
        if (transform.position.x <= -width)
        {
            transform.position += new Vector3(width * 2f, 0, 0);
        }
    }
}