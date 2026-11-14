
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BallController : MonoBehaviour
{
    public float speed = 5f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        Vector2 direction = new Vector2(3f, 5f).normalized;
        rb.linearVelocity = direction * speed;
    }//Start

    void Update()
    {

        BallBoundaries();


    }//Update

    public void BallBoundaries()
    {
        if (transform.position.x < -12f)
        {
            transform.position = new Vector2(-12f, transform.position.y);
        }
        else if (transform.position.x >12f)
        {
            transform.position = new Vector2(12f, transform.position.y);
        }

        if (transform.position.y > 5.8f)
        {
            transform.position = new Vector2(transform.position.x, 5.8f);
        }
    }//BallBoundaries
}

