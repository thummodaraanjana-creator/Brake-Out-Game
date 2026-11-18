using UnityEngine;

public class BrickController : MonoBehaviour
{
    public ScoreManager scoreManager;
    public WinManager winManager;

    // Prefabs for power-ups
    public GameObject extraLifePowerUpPrefab;
    public GameObject tripleBallPowerUpPrefab;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            scoreManager.AddScore();

            winManager.BrickDestroyed();

            // Randomly decide if a power-up drops (for example, 1 out of every 3 bricks)
            int randomChance = Random.Range(0, 3); // Generates 0, 1, or 2

            if (randomChance == 0 && extraLifePowerUpPrefab != null)
            {
                Instantiate(extraLifePowerUpPrefab, transform.position, Quaternion.identity);
            }
            else if (randomChance == 1 && tripleBallPowerUpPrefab != null)
            {
                Instantiate(tripleBallPowerUpPrefab, transform.position, Quaternion.identity);
            }

            Destroy(gameObject);
        }
    }
}