using UnityEngine;

public class TwoHitBrick : MonoBehaviour
{
    public Sprite brokenSprite;

    private int hitsRemaining = 2;

    private SpriteRenderer spriteRenderer;

    private ScoreManager scoreManager;
    private WinManager winManager;

    // NEW: Prefabs for power-ups so TwoHitBricks can drop them too
    public GameObject extraLifePowerUpPrefab;
    public GameObject tripleBallPowerUpPrefab;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        scoreManager = FindObjectOfType<ScoreManager>();
        winManager = FindObjectOfType<WinManager>();
    }

    public void HitBrick()
    {
        hitsRemaining--;

        // First hit
        if (hitsRemaining == 1)
        {
            spriteRenderer.sprite = brokenSprite;

            scoreManager.AddScore();
        }

        // Second hit
        else if (hitsRemaining <= 0)
        {
            scoreManager.AddScore();

            winManager.BrickDestroyed();

            // NEW: Randomly decide if a power-up drops when destroyed
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

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            HitBrick();
        }
    }
}