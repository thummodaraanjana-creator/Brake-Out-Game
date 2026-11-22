
using UnityEngine;

public class WinManager : MonoBehaviour
{
    public GameObject winText;
    public GameObject restartButton;

    private int bricksRemaining;

    void Start()
    {
        winText.SetActive(false);
        restartButton.SetActive(false);

        // Count all bricks in the current level
        GameObject[] bricks = GameObject.FindGameObjectsWithTag("Brick");

        bricksRemaining = bricks.Length;

        Debug.Log("Total Bricks: " + bricksRemaining);
    }

    public void BrickDestroyed()
    {
        bricksRemaining--;

        Debug.Log("Bricks Remaining: " + bricksRemaining);

        // Show win message only when every brick is destroyed
        if (bricksRemaining == 0)
        {
            winText.SetActive(true);
            restartButton.SetActive(true);

            Time.timeScale = 0f;

            Debug.Log("YOU WIN!");
        }
    }
}
