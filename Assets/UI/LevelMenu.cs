using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMenu : MonoBehaviour
{
    public Button[] buttons;
    // Unlockable levels
    private void Awake()
    {
        int unlockedLevel = PlayerPrefs.GetInt("Unlocked level", 1);    // first level always unlock

        // before unlock
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }

        // after unlock
        for (int i = 0; i < unlockedLevel; i++)
        {
            buttons[i].interactable = true;
        }
    }

    // All levels
    public void OpenLevel(int levelID)
    {
        string levelName = "Level " + levelID;
        SceneManager.LoadScene(levelName);
    }
}
