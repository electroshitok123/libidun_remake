using UnityEngine;

public class PundusWalk : MonoBehaviour
{
    public float speed; //переменная задает скорость передвижения
    public float jumpForce;

    float movX; //показывает есть ли сейчас передвижение по оси x

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        movX = 0;
    }

    void Update()
    {
        rb.linearVelocity = new Vector2(movX * speed, 0);

        //if (Input.GetKey(KeyCode.I))
        //{
        //    rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        //}

        if (Input.GetKey(KeyCode.L))
        {
            movX = 1;
        }

        if (Input.GetKey(KeyCode.J))
        {
            movX = -1;
        }
    }
}
