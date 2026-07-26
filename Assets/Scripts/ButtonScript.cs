using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public int flagOnButton = 0;
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
