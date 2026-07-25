using UnityEngine;

public class KustusWall : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("KustusBullet"))
        {
            Destroy(gameObject);
        }
    }
}
