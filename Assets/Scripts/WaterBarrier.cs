using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class WaterBarrier : MonoBehaviour
{
    public GameObject panel;
    public GameObject KustusText;
    public GameObject PundusText;
    public GameObject LibidunText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        LibidunText.SetActive(false);
        if (collision.CompareTag("Kustus"))
        {
            StopPlay();
            KustusText.SetActive(true);
        }
        else if (collision.CompareTag("Pundus"))
        {
            StopPlay();
            PundusText.SetActive(true);
        }
    }
    public void ContinuePlay()
    {
        panel.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StopPlay()
    {
        panel.SetActive(true);
        Time.timeScale = 0f;
    }
}