using UnityEngine;

public class PundusWalk : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private float jumpForce = 15f;
    private float movX;
    private float movY;

    private Rigidbody2D rb;
    private SpriteRenderer sprite;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        movX = 0;
        movY = 0;
    }

    private void Update()
    {

    }
}
