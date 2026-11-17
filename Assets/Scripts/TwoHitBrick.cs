
using UnityEngine;

public class TwoHitBrick : MonoBehaviour
{
    public Sprite brokenSprite;

    private int hitsRemaining = 2;

    private SpriteRenderer spriteRenderer;

    private ScoreManager scoreManager;
    private WinManager winManager;

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
