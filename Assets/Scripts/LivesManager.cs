
using UnityEngine;
using TMPro;

public class LivesManager : MonoBehaviour
{
    public TextMeshProUGUI livesText;

    private int lives = 3;

    public void LoseLife()
    {
        lives = lives - 1;

        livesText.text = "Lives: " + lives;

        if (lives <= 0)
        {
            Debug.Log("Game Over!");
        }
    }
}
