using UnityEngine;

public class KustusDoor : MonoBehaviour
{
    public DoorsCounter DoorsCounter;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Kustus"))
        {
            DoorsCounter.AddScore(1);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Kustus"))
        {
            DoorsCounter.RemoveScore(1);
        }
    }
}
