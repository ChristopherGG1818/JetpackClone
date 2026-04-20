using UnityEngine;

public class LaserSpawner : MonoBehaviour
{
    public GameObject laserPrefab;

    public float spawnRate = 10f;
    public float spawnX = 12f;

    public float minY = -4.683f;
    public float maxY = 4.683f;

    void Start()
    {
        InvokeRepeating(nameof(SpawnLaser), 10f, spawnRate);
    }

    void SpawnLaser()
    {
        // only TOP or BOTTOM (no middle spawns)
        float y = (Random.value < 0.5f) ? minY : maxY;

        Vector3 spawnPos = new Vector3(spawnX, y, 0f);

        Instantiate(laserPrefab, spawnPos, Quaternion.identity);
    }
}