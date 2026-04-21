using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;
    public float spawnRate = 1.2f;
    public float spawnX = 12f;
    public float minY = -4f;
    public float maxY = 4f;

    void Start()
    {
        InvokeRepeating(nameof(SpawnCoin), 1f, spawnRate);
    }

    void SpawnCoin()
    {
        float y = Random.Range(minY, maxY);
        Vector3 spawnPos = new Vector3(spawnX, y, 0f);
        Instantiate(coinPrefab, spawnPos, Quaternion.identity);
    }
}