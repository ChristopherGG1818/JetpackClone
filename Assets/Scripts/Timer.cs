using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;

    private float timeAlive;

    void Update()
    {
        timeAlive += Time.deltaTime;

        int seconds = Mathf.FloorToInt(timeAlive % 60);
        int minutes = Mathf.FloorToInt(timeAlive / 60);

        timerText.text = "Time: "+ string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}