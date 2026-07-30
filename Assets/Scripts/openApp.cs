using UnityEngine;
using System.Diagnostics;

public class openApp : MonoBehaviour
{
    public void openDesktopApp()
    {
        try
        {
            Process.Start("C:\\Program Files\\Blender Foundation\\Blender 5.1\\blender-launcher.exe");
        }
        catch (System.Exception e) 
        {
            UnityEngine.Debug.Log("Не удалось запустить файл: " + e.Message);
        }
    }
}
