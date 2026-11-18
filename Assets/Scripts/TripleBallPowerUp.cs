using UnityEngine;

public class TripleBallPowerUp : MonoBehaviour
{
    public float fallSpeed = 3f;

    void Update()
    {
        // Make the power-up fall downwards every frame
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);

        // Destroy if it falls off the bottom of the screen
        if (transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the paddle touched the power-up
        if (collision.CompareTag("Player") || collision.gameObject.name.Contains("Paddle"))
        {
            Debug.Log("Paddle caught Triple Ball!"); // <-- Check if this prints in the Console!

            // Find all balls currently in the game
            BallController[] existingBalls = FindObjectsOfType<BallController>();

            Debug.Log("Balls found: " + existingBalls.Length); // <-- Check how many balls it finds!

            if (existingBalls.Length > 0)
            {
                Transform currentBallTransform = existingBalls[0].transform;
                GameObject ballPrefab = existingBalls[0].gameObject;

                GameObject ball2 = Instantiate(ballPrefab, currentBallTransform.position, Quaternion.identity);
                Rigidbody2D rb2 = ball2.GetComponent<Rigidbody2D>();
                if (rb2 != null)
                {
                    rb2.linearVelocity = new Vector2(-3f, 5f).normalized * 5f;
                }

                GameObject ball3 = Instantiate(ballPrefab, currentBallTransform.position, Quaternion.identity);
                Rigidbody2D rb3 = ball3.GetComponent<Rigidbody2D>();
                if (rb3 != null)
                {
                    rb3.linearVelocity = new Vector2(3f, 5f).normalized * 5f;
                }
            }

            Destroy(gameObject);
        }
    }
}