using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public float speed = 10f;

    void Update()
    {
        PaddleMove();


    }//Update

    public void PaddleMove()
    {
        float move = Input.GetAxis("Horizontal");

        transform.Translate(Vector2.right * move * speed * Time.deltaTime);

        if (transform.position.x < -2.2f)
        {
            transform.position = new Vector2(-2.2f, transform.position.y);
        }
        else if (transform.position.x > 2.2f)
        {
            transform.position = new Vector2(2.2f, transform.position.y);
        }
    }//PaddleMove & paddleBoundries
}