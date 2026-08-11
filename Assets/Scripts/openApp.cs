using UnityEngine;
using System.Diagnostics;

public class openApp : MonoBehaviour
{
    public void openDesktopApp()
    {
        try
        {
            Process.Start("\"C:\\Users\\domofon\\Desktop\\либидун и пундус rimeyk\\rimeyk\\libidun_remake\\Assets\\Scripts\\win32calc.exe\"");
        }
        catch (System.Exception e) 
        {
            UnityEngine.Debug.Log("Не удалось запустить файл: " + e.Message);
        }
    }
}
