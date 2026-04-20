using UnityEngine;

public class Coin : MonoBehaviour
{
    public float moveSpeed = 4f;   // slightly faster feels more Jetpack-like
    public float destroyX = -12f;  // off-screen left

    void Update()
    {
        // move left across screen
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        // destroy if it goes off-screen
        if (transform.position.x < destroyX)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            CoinManager.Instance.AddCoin(1);

            // optional: prevents double trigger bugs
            Destroy(gameObject);
        }
    }
}