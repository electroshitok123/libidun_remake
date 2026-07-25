using UnityEngine;

public class KustusDoor : MonoBehaviour
{
    public DoorsCounter DoorsCounter;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

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
