using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Runtime.InteropServices;

public class pauseObject : MonoBehaviour
{
    public GameObject panel;

    void Start()
    {
        panel.SetActive(false);
        Time.timeScale = 1f;
    }

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
        WindowsMessageBox.MessageBox(IntPtr.Zero, "Нет.", "Нет.", 0);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public class WindowsMessageBox : MonoBehaviour
    {
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        public static extern int MessageBox(IntPtr hWnd, string text, string caption, uint type);
    }
}
