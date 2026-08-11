using UnityEngine;

public class BulletFlight : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    private SpriteRenderer sprite;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 reverseFlight = new Vector3(-1f, 0f, 0f); 
        transform.Translate(reverseFlight * speed * Time.deltaTime);
        sprite.flipX = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }

        if (gameObject.CompareTag("PundusBullet") && collision.CompareTag("WaterBarrier") || collision.CompareTag("SpikesBarrier"))
        {
            Destroy(gameObject);
        }
        
        if (gameObject.CompareTag("LibidunBullet") && collision.CompareTag("FireBarrier") || collision.CompareTag("SpikesBarrier"))
        {
            Destroy(gameObject);
        }

        if (gameObject.CompareTag("KustusBullet") && collision.CompareTag("WaterBarrier") || collision.CompareTag("SpikesBarrier") || collision.CompareTag("FireBarrier"))
        {
            Destroy(gameObject);
        }
    }
}
