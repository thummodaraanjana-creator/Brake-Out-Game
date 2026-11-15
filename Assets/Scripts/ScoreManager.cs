
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
}//class
