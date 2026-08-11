using UnityEngine;
using UnityEngine.SceneManagement;

public class SpikesBarrier : MonoBehaviour
{
    public GameObject panel;
    public GameObject PundusText;
    public GameObject LibidunText;
    public GameObject KustusText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Pundus"))
        {
            StopPlay();
            PundusText.SetActive(true);
        }
        if (collision.CompareTag("Libidun"))
        {
            StopPlay();
            LibidunText.SetActive(true);
        }
        if (collision.CompareTag("Kustus"))
        {
            StopPlay();
            KustusText.SetActive(true);
        }
    }

    public void StopPlay()
    {
        panel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ContinuePlay()
    {
        panel.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
