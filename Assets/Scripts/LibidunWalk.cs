using UnityEngine;

public class LibidunWalk : MonoBehaviour
{
    public float moveSpeed = 5f;    // Скорость перемещения
    public float jumpForce = 10f;   // Множитель прыжка
    public Transform groundCheck;   // Проверка стояния на земое
    public float groundCheckRadius = 0.2f;  // Радиус пребывания рядом с землёй
    public LayerMask groundLayer;

    private bool isGrounded;
    private float moveInput;
    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);     // Проверка есть ли земля под ногами

        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    // FixedUpdate независим от кадров в секунду в отличие от Update, что избавляет от необходимости прописывать Time.DeltaTime
    void FixedUpdate()
    {
        float x = 0f;
        float y = 0f;
        if (Input.GetKey(KeyCode.D))
            x += moveSpeed;
        if (Input.GetKey(KeyCode.A))
            x -= moveSpeed;

        rb.linearVelocity = new Vector2(x, rb.linearVelocity.y);
    }
}