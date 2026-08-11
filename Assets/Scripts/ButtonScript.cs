using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public int flagOnButton = 0;
    Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (flagOnButton == 1)
        {
            animator.SetBool("isOnButton", true);
        }
        else
        {
            animator.SetBool("isOnButton", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Box"))
        {
            flagOnButton = 1;
        }
        else if (collision.CompareTag("Pundus"))
        {
            flagOnButton = 1;
        }
        else if (collision.CompareTag("Libidun"))
        {
            flagOnButton = 1;
        }
        else if (collision.CompareTag("Kustus"))
        {
            flagOnButton = 1;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Box"))
        {
            flagOnButton = 0;
        }
        else if (collision.CompareTag("Pundus"))
        {
            flagOnButton = 0;
        }
        else if (collision.CompareTag("Libidun"))
        {
            flagOnButton = 0;
        }
        else if (collision.CompareTag("Kustus"))
        {
            flagOnButton = 0;
        }
    }


}
