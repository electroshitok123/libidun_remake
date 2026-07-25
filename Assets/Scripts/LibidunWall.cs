using UnityEngine;

public class LibidunWall : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("LibidunBullet"))
        {
            Destroy(gameObject);
        }
    }
}