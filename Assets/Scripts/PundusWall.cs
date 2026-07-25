using UnityEngine;

public class PundusWall : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PundusBullet"))
        {
            Destroy(gameObject);
        }
    }
}
