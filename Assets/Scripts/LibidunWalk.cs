using UnityEngine;

public class LibidunWalk : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    private bool isGrounded;
    private float moveInput;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator animator; // Аниматор

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Компонент физики
        sprite = GetComponent<SpriteRenderer>(); // Компонент спрайтов
        animator = GetComponent<Animator>(); // Компонент анимации
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        UpdateAnimations(); // Проигрывание анимаций
    }

    void FixedUpdate()
    {
        float x = 0f;
        if (Input.GetKey(KeyCode.D))
        {
            x += moveSpeed;
            sprite.flipX = true;
        }
        if (Input.GetKey(KeyCode.A))
        {
            x -= moveSpeed;
            sprite.flipX = false;
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
        animator.SetFloat("verticalSpeed", rb.linearVelocity.y);
    }
}