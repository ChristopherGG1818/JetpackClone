using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    public GameObject meteorPrefab;

    public float spawnX = 12f;

    public float minY = -4f;
    public float maxY = 4f;

    public float startSpawnRate = 1.5f;   // slow at start
    public float minSpawnRate = 0.4f;     // fastest limit

    public float difficultyIncrease = 0.01f; // how fast it ramps

    private float currentSpawnRate;
    private float timer;

    void Start()
    {
        currentSpawnRate = startSpawnRate;
    }

    void Update()
    {
        // increase difficulty over time
        if (currentSpawnRate > minSpawnRate)
        {
            currentSpawnRate -= difficultyIncrease * Time.deltaTime;
        }

        timer += Time.deltaTime;

        if (timer >= currentSpawnRate)
        {
            SpawnMeteor();
            timer = 0f;
        }
    }

    void SpawnMeteor()
    {
        float y = Random.Range(minY, maxY);

        Vector3 spawnPos = new Vector3(spawnX, y, 0f);

        Instantiate(meteorPrefab, spawnPos, Quaternion.identity);
    }
}