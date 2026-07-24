using UnityEngine;

public class BulletFlight : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
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
}
