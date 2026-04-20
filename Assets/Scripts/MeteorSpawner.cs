using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    public GameObject meteorPrefab;

    public float spawnRate = 1.5f;

    public float spawnX = 12f;

    public float minY = -4f;
    public float maxY = 4f;

    void Start()
    {
        InvokeRepeating(nameof(SpawnMeteor), 1f, spawnRate);
    }

    void SpawnMeteor()
    {
        float y = Random.Range(minY, maxY);

        Vector3 spawnPos = new Vector3(spawnX, y, 0f);

        Instantiate(meteorPrefab, spawnPos, Quaternion.identity);
    }
}