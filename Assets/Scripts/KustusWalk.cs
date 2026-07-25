using UnityEngine;

public class KustusWalk : MonoBehaviour
{
    public float moveSpeed = 5f;    // Скорость перемещения
    public float jumpForce = 10f;   // Множитель прыжка
    public Transform groundCheck;   // Проверка стояния на земое
    public float groundCheckRadius = 0.2f;  // Радиус пребывания рядом с землёй
    public LayerMask groundLayer;
    public Transform shootingPoint;    //родительский обьект точки стрельбы
    public Transform shootingPointSpawn;
    public GameObject bulletKustus;

    private bool isGrounded;
    private float moveInput;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);     // Проверка есть ли земля под ногами

        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            GameObject bulletChild = Instantiate(bulletKustus, shootingPointSpawn);
            bulletChild.transform.SetParent(null);
        }
    }

    // FixedUpdate независим от кадров в секунду в отличие от Update, что избавляет от необходимости прописывать Time.DeltaTime
    void FixedUpdate()
    {
        Vector3 shootingRotRight = transform.eulerAngles;
        shootingRotRight.z = 180f;  //Задать угол поворота (в этом случае 180 - то есть право)
        Vector3 shootingRotLeft = transform.eulerAngles;
        shootingRotLeft.z = 0f; //Задать угол поворота (в этом случае 0 - то есть лево)
        float x = 0f;
        float y = 0f;
        if (Input.GetKey(KeyCode.RightArrow))
        {
            x += moveSpeed;
            sprite.flipX = false;
            shootingPoint.transform.eulerAngles = shootingRotRight;     //назначаем родительскому обьекту поворот направо
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            x -= moveSpeed;
            sprite.flipX = true;
            shootingPoint.transform.eulerAngles = shootingRotLeft;      //назначаем родительскому обьекту поворот налево
        }
        rb.linearVelocity = new Vector2(x, rb.linearVelocity.y);
    }
}
