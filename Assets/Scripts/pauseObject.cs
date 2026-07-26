using UnityEngine;

public class pauseObject : MonoBehaviour
{
    public GameObject panel;

    void Update()
    {
        if (panel.activeSelf == false && Input.GetKeyDown(KeyCode.Escape))
        {
            panel.SetActive(true);
            Time.timeScale = 0f;
        }
        else if (panel.activeSelf == true && Input.GetKeyDown(KeyCode.Escape))
        {
            panel.SetActive(false);
            Time.timeScale = 1f;
        }
    }
    public void ContinuePlay()
    {
        panel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Settings()
    {
        //сюда надочотапридуматьчтоб глобальноменятьнастройки
        //We need to come up with something here to change settings globally.
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
