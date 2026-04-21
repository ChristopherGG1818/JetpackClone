using UnityEngine;

public class Coin : MonoBehaviour
{
    public float moveSpeed = 4f;
    public float destroyX = -12f;
    public AudioClip collectSound;

    void Update()
    {
        float speed = GameSpeedManager.Instance.GetSpeed();
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        if (transform.position.x < destroyX)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //CoinManager.Instance.AddCoin(1);
            //Destroy(gameObject);
            

            Debug.Log("Coin collected! Sound clip is: " + collectSound); // Add this
            CoinManager.Instance.AddCoin(1);
            PlayCollectSound();
            Destroy(gameObject);
        }
    }
    void PlayCollectSound()
    {
        if (collectSound != null)
        {
            // PlayClipAtPoint plays audio even after the object is destroyed
            AudioSource.PlayClipAtPoint(collectSound, transform.position);
        }
    }
}