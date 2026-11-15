
using UnityEngine;

public class BottomBoundary : MonoBehaviour
{
    public LivesManager livesManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))
        {
            livesManager.LoseLife();

            Destroy(collision.gameObject);
        }
    }
}
