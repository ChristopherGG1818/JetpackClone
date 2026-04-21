using UnityEngine;

public class GameSpeedManager : MonoBehaviour
{
    public static GameSpeedManager Instance;

    public float baseSpeed = 4f;
    public float speedIncreaseRate = 0.1f; // how fast it ramps

    private float startTime;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        startTime = Time.time;
    }

    public float GetSpeed()
    {
        float timeAlive = Time.time - startTime;
        return baseSpeed + (timeAlive * speedIncreaseRate);
    }
}