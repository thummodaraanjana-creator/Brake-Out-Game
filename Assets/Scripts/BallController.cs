
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BallController : MonoBehaviour
{
    public float speed = 5f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        LaunchBall();
    }

    public void LaunchBall()
    {
        Vector2 direction = new Vector2(3f, 5f).normalized;

        rb.linearVelocity = direction * speed;
    }

    public void RespawnBall()
    {
        rb.linearVelocity = Vector2.zero;

        transform.position = new Vector2(0f, -2f);

        LaunchBall();
    }
}
