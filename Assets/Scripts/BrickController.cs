
using UnityEngine;

public class BrickController : MonoBehaviour
{
    public ScoreManager scoreManager;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            scoreManager.AddScore();

            Destroy(gameObject);
        }
    }
}
