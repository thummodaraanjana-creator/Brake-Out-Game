
using UnityEngine;
using TMPro;

public class LivesManager : MonoBehaviour
{
    public TextMeshProUGUI livesText;
    public GameObject gameOverText;
    public GameObject restartButton;

    private int lives = 3;

    void Start()
    {
        gameOverText.SetActive(false);
        restartButton.SetActive(false);

        Time.timeScale = 1f;
    }

    public void LoseLife()
    {
        lives = lives - 1;

        livesText.text = "Lives: " + lives;

        if (lives <= 0)
        {
            gameOverText.SetActive(true);
            restartButton.SetActive(true);

            Time.timeScale = 0f;
        }
    }
}
