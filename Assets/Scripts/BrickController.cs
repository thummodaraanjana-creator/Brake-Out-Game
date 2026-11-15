
using UnityEngine;

public class BrickController : MonoBehaviour
{
    public ScoreManager scoreManager;
    public WinManager winManager;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            scoreManager.AddScore();

            winManager.BrickDestroyed();

            Destroy(gameObject);
        }
    }
}
