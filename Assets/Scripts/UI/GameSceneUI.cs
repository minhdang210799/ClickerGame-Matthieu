using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneUI : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI scoreText;
    [Space]
    public GameObject gameOverPanel;

    private void Start()
    {
        Time.timeScale = 1;
        gameOverPanel.SetActive(false);
    }

    public void AddScore(int score)
    {
        this.score += score;
        scoreText.text = this.score.ToString();
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("SceneManager");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
