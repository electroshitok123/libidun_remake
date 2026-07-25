using UnityEngine;

public class PundusWalk : MonoBehaviour
{
    public float moveSpeed = 5f;    // Ñêîðîñòü ïåðåìåùåíèÿ
    public float jumpForce = 10f;   // Ìíîæèòåëü ïðûæêà
    public Transform groundCheck;   // Ïðîâåðêà ñòîÿíèÿ íà çåìîå
    public float groundCheckRadius = 0.2f;  // Ðàäèóñ ïðåáûâàíèÿ ðÿäîì ñ çåìë¸é
    public LayerMask groundLayer;
    public Transform shootingPoint;    //ðîäèòåëüñêèé îáüåêò òî÷êè ñòðåëüáû
    public Transform shootingPointSpawn;
    public GameObject bulletPundus;

    private bool isGrounded;
    private float moveInput;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator animator;      // Äîáàâëÿåò àíèìàòîð

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>(); // Àíèìàòîð
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);     // Ïðîâåðêà åñòü ëè çåìëÿ ïîä íîãàìè

        if (Input.GetKeyDown(KeyCode.I) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        UpdateAnimations();

        if (Input.GetKeyDown(KeyCode.O))
        {
            GameObject bulletChild = Instantiate(bulletPundus, shootingPointSpawn);
            bulletChild.transform.SetParent(null);
        }

    }

    // FixedUpdate íåçàâèñèì îò êàäðîâ â ñåêóíäó â îòëè÷èå îò Update, ÷òî èçáàâëÿåò îò íåîáõîäèìîñòè ïðîïèñûâàòü Time.DeltaTime
    void FixedUpdate()
    {
        Vector3 shootingRotRight = transform.eulerAngles;
        shootingRotRight.z = 180f;  //Çàäàòü óãîë ïîâîðîòà (â ýòîì ñëó÷àå 180 - òî åñòü ïðàâî)
        Vector3 shootingRotLeft = transform.eulerAngles;
        shootingRotLeft.z = 0f; //Çàäàòü óãîë ïîâîðîòà (â ýòîì ñëó÷àå 0 - òî åñòü ëåâî)
        float x = 0f;
        float y = 0f;
        if (Input.GetKey(KeyCode.L))
        {
            x += moveSpeed;
            sprite.flipX = false;
            shootingPoint.transform.eulerAngles = shootingRotRight;     //íàçíà÷àåì ðîäèòåëüñêîìó îáüåêòó ïîâîðîò íàïðàâî
        }
        if (Input.GetKey(KeyCode.J))
        {
            x -= moveSpeed;
            sprite.flipX = true;
            shootingPoint.transform.eulerAngles = shootingRotLeft;      //íàçíà÷àåì ðîäèòåëüñêîìó îáüåêòó ïîâîðîò íàëåâî
        }
        rb.linearVelocity = new Vector2(x, rb.linearVelocity.y);
    }
    // Ìåòîä äëÿ àíèìàöèè
    void UpdateAnimations()
    {
        if (animator == null)
            return;

        bool isMoving = Mathf.Abs(rb.linearVelocity.x) > 0.1f;

        animator.SetBool("isMoving", isMoving);
        animator.SetBool("isGrounded", isGrounded);
    }
}