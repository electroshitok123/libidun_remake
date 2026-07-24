using UnityEngine;

public class PundusWalk : MonoBehaviour
{
    public float moveSpeed = 5f;    // Скорость перемещения
    public float jumpForce = 10f;   // Множитель прыжка
    public Transform groundCheck;   // Проверка стояния на земое
    public float groundCheckRadius = 0.2f;  // Радиус пребывания рядом с землёй
    public LayerMask groundLayer;

    private bool isGrounded;
    private float moveInput;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator animator;      // Добавляет аниматор

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>(); // Аниматор
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);     // Проверка есть ли земля под ногами

        if (Input.GetKeyDown(KeyCode.I) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
        UpdateAnimations();
    }

    // FixedUpdate независим от кадров в секунду в отличие от Update, что избавляет от необходимости прописывать Time.DeltaTime
    void FixedUpdate()
    {
        float x = 0f;
        float y = 0f;
        if (Input.GetKey(KeyCode.L))
        {
            x += moveSpeed;
            sprite.flipX = false;
        }
        if (Input.GetKey(KeyCode.J))
        {
            x -= moveSpeed;
            sprite.flipX = true;
        }
        rb.linearVelocity = new Vector2(x, rb.linearVelocity.y);
    }
    // Метод для анимации
    void UpdateAnimations()
    {
        if (animator == null)
            return;

        bool isMoving = Mathf.Abs(rb.linearVelocity.x) > 0.1f;

        animator.SetBool("isMoving", isMoving);
        animator.SetBool("isGrounded", isGrounded);
    }
}