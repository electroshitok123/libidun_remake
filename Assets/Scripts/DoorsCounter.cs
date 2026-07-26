using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorsCounter : MonoBehaviour
{
    public int doors;

    private void Start()
    {
        doors = 0;
    }
    private void Update()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        int nextIndex = currentIndex + 1;
        if (doors == 3)
        {
            UnlockLevel();
            PlayerPrefs.Save();
            SceneManager.LoadScene(nextIndex);
        }
    }

    public void UnlockLevel()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        if (currentLevel >= PlayerPrefs.GetInt("levels", 1))
        {
            PlayerPrefs.SetInt("levels", currentLevel + 1);
        }
    }

    public void AddScore(int amount)
    {
        doors += amount;
    }

    public void RemoveScore(int amount)
    {
        doors -= amount;
    }
}
