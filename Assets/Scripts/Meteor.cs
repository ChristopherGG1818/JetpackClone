using UnityEngine;
using UnityEngine.SceneManagement;

public class Meteor : MonoBehaviour
{
    public float moveSpeed = 5f;

    void Update()
    {
        // move left like obstacles in Jetpack Joyride
        float speed = GameSpeedManager.Instance.GetSpeed();
        transform.position += Vector3.left * speed * Time.deltaTime;

        // clean up off-screen meteors
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