using UnityEngine;

public class BottomBoundary : MonoBehaviour
{
    public LivesManager livesManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))
        {
            // Count how many balls are currently in the scene
            BallController[] remainingBalls = FindObjectsOfType<BallController>();

            // If there is more than 1 ball, just destroy the ball that fell
            if (remainingBalls.Length > 1)
            {
                Destroy(collision.gameObject);
            }
            // If this was the LAST ball, lose a life and respawn it
            else
            {
                livesManager.LoseLife();

                BallController ball = collision.GetComponent<BallController>();
                if (ball != null)
                {
                    ball.RespawnBall();
                }
            }
        }
    }
}