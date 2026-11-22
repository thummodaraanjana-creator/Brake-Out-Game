
using UnityEngine;

public class TwoHitBrick : MonoBehaviour
{
    public Sprite brokenSprite;

    private int hitsRemaining = 2;
    private bool isDestroyed = false;

    private SpriteRenderer spriteRenderer;

    public ScoreManager scoreManager;
    public WinManager winManager;

    public GameObject extraLifePowerUpPrefab;
    public GameObject tripleBallPowerUpPrefab;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void HitBrick()
    {
        if (isDestroyed)
            return;

        hitsRemaining--;

        if (hitsRemaining == 1)
        {
            spriteRenderer.sprite = brokenSprite;

            if (scoreManager != null)
                scoreManager.AddScore();
        }
        else if (hitsRemaining <= 0)
        {
            isDestroyed = true;

            if (scoreManager != null)
                scoreManager.AddScore();

            if (winManager != null)
                winManager.BrickDestroyed();

            int dropRoll = Random.Range(0, 3);

            if (dropRoll == 0 && extraLifePowerUpPrefab != null)
            {
                Instantiate(extraLifePowerUpPrefab,
                    transform.position, Quaternion.identity);
            }
            else if (dropRoll == 1 && tripleBallPowerUpPrefab != null)
            {
                Instantiate(tripleBallPowerUpPrefab,
                    transform.position, Quaternion.identity);
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
