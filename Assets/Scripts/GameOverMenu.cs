using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public void RetryGame()
    {
        Time.timeScale = 1f; // VERY IMPORTANT (unpause game)
        SceneManager.LoadScene("Rocket"); // your gameplay scene name
        
    }
    public void GMenu()
    {
        Time.timeScale = 1f; // VERY IMPORTANT (unpause game)
        SceneManager.LoadScene("Main Menu"); // your gameplay scene name
        
    }
}