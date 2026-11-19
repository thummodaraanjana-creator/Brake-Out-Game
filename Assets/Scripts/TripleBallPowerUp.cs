using UnityEngine;

public class TripleBallPowerUp : MonoBehaviour
{
    public float fallSpeed = 3f;

    // Drag your Ball prefab from the Project window into this slot
    public GameObject ballPrefab;

    void Update()
    {
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);

        if (transform.position.y < -7f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.gameObject.name.Contains("Paddle"))
        {
            BallController mainBall = FindObjectOfType<BallController>();

            if (mainBall != null)
            {
                // Use the assigned Ball prefab, or fall back to the active ball if empty
                GameObject templateBall = ballPrefab != null ? ballPrefab : mainBall.gameObject;
                Vector3 spawnPos = mainBall.transform.position;
                float ballSpeed = mainBall.speed;

                // Spawn Ball 2 slightly to the left
                GameObject ball2 = Instantiate(templateBall, spawnPos + new Vector3(-0.2f, 0f, 0f), Quaternion.identity);
                Rigidbody2D rb2 = ball2.GetComponent<Rigidbody2D>();
                if (rb2 != null)
                {
                    rb2.linearVelocity = new Vector2(-3f, 5f).normalized * ballSpeed;
                }

                // Spawn Ball 3 slightly to the right
                GameObject ball3 = Instantiate(templateBall, spawnPos + new Vector3(0.2f, 0f, 0f), Quaternion.identity);
                Rigidbody2D rb3 = ball3.GetComponent<Rigidbody2D>();
                if (rb3 != null)
                {
                    rb3.linearVelocity = new Vector2(3f, 5f).normalized * ballSpeed;
                }
            }

            Destroy(gameObject);
        }
    }
}