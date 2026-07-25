using UnityEngine;

public class PundusDoor : MonoBehaviour
{
    public DoorsCounter DoorsCounter;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Pundus"))
        {
            DoorsCounter.AddScore(1);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Pundus"))
        {
            DoorsCounter.RemoveScore(1);
        }
    }
}
