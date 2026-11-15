
using UnityEngine;

public class WinManager : MonoBehaviour
{
    public GameObject winText;
    public GameObject restartButton;

    private int bricksRemaining = 6;

    void Start()
    {
        winText.SetActive(false);
    }

    public void BrickDestroyed()
    {
        bricksRemaining = bricksRemaining - 1;

        if (bricksRemaining <= 0)
        {
            winText.SetActive(true);
            restartButton.SetActive(true);

            Time.timeScale = 0f;
        }
    }
}
