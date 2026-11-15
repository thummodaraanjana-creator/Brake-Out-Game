
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    private int score = 0;

    public void AddScore()
    {
        score = score + 10;

        scoreText.text = "Score: " + score;
    }//AddScore

    public void RestartGame()
    {
        Time.timeScale = 1f;

        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex
        );
    }//RestartGame
}//class
