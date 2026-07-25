using UnityEngine;

public class LibidunDoor : MonoBehaviour
{
    public DoorsCounter DoorsCounter;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Libidun"))
        {
            DoorsCounter.AddScore(1);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Libidun"))
        {
            DoorsCounter.RemoveScore(1);
        }
    }
}
