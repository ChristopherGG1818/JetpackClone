using UnityEngine;
using UnityEngine.SceneManagement;

public class Laser : MonoBehaviour
{
    public float moveSpeed = 6f;

    void Update()
    {
        // move left (same style as meteor)
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        // destroy off-screen
        if (transform.position.x < -15f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("Game Over");
        }
    }
}