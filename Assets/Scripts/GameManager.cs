using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject winPanel;

    public void WinGame()
    {
        Debug.Log("You Win! Game Over.");
        winPanel.SetActive(true); // Show Win Panel
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameOverPanel.SetActive(false); //ensures panel is off when the game starts
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true); //enables panel when game is over
    }

    public void RetryGame()
    {
        SceneManager.LoadScene("GameScene"); //reloads current level
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenuScene"); //Loads the main menu.
    }

}
