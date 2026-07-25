using UnityEngine;

public class PundusDoor : MonoBehaviour
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
