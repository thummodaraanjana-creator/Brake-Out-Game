using UnityEngine;

public class ExtraLifePowerUp : MonoBehaviour
{
    public float fallSpeed = 3f;

    void Update()
    {
        // Make the heart fall downwards every frame
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);

        // Destroy the heart if it falls off the bottom of the screen
        if (transform.position.y < -7f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the paddle touched the heart
        if (collision.CompareTag("Player") || collision.gameObject.name.Contains("Paddle"))
        {
            // Find the LivesManager in the scene and add a life
            LivesManager livesManager = FindObjectOfType<LivesManager>();
            if (livesManager != null)
            {
                livesManager.AddLife();
            }

            // Destroy the heart power-up object
            Destroy(gameObject);
        }
    }
}