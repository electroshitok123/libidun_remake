using Unity.VisualScripting;
using UnityEngine;

public class LibidunWalk : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    public Transform shootingPoint;    //ðîäèòåëüñêèé îáüåêò òî÷êè ñòðåëüáû
    public Transform shootingPointSpawn;
    public GameObject bulletLibibdun;

    private bool isGrounded;
    private float moveInput;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator animator; // Àíèìàòîð

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Êîìïîíåíò ôèçèêè
        sprite = GetComponent<SpriteRenderer>(); // Êîìïîíåíò ñïðàéòîâ
        animator = GetComponent<Animator>(); // Êîìïîíåíò àíèìàöèè 
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }


        UpdateAnimations(); // Ïðîèãðûâàíèå àíèìàöèé

        if (Input.GetKeyDown(KeyCode.E))
        {
            GameObject bulletChild = Instantiate(bulletLibibdun, shootingPointSpawn);
            bulletChild.transform.SetParent(null);
        }

    }

    void FixedUpdate()
    {
        // Shoot
        Vector3 shootingRotRight = transform.eulerAngles;   
        shootingRotRight.z = 180f;  //Çàäàòü óãîë ïîâîðîòà (â ýòîì ñëó÷àå 180 - òî åñòü ïðàâî)
        Vector3 shootingRotLeft = transform.eulerAngles;
        shootingRotLeft.z = 0f; //Çàäàòü óãîë ïîâîðîòà (â ýòîì ñëó÷àå 0 - òî åñòü ëåâî)

        // Walk
        float x = 0f;
        if (Input.GetKey(KeyCode.D))
        {
            x += moveSpeed;
            sprite.flipX = true;
            shootingPoint.transform.eulerAngles = shootingRotRight;
        }
        if (Input.GetKey(KeyCode.A))
        {
            x -= moveSpeed;
            sprite.flipX = false;
            shootingPoint.transform.eulerAngles = shootingRotLeft;
        }
        rb.linearVelocity = new Vector2(x, rb.linearVelocity.y);
    }

    // Animation
    void UpdateAnimations()
    {
        if (animator == null)
            return;

        bool isMoving = Mathf.Abs(rb.linearVelocity.x) > 0.1f;

        animator.SetBool("isMoving", isMoving);
        animator.SetBool("isGrounded", isGrounded);
    }
}