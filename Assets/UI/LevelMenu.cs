using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMenu : MonoBehaviour
{
    public Button[] buttons;
    int unlockedLevel;
    // Unlockable levels
    void Start()
    {
        unlockedLevel = PlayerPrefs.GetInt("level", 1);    // first level always unlock

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
        SceneManager.LoadScene(levelID);
    }
}
