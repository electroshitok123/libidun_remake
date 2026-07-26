using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorsCounter : MonoBehaviour
{
    public int doors;

    private void Update()
    {
        LoadNextScene();
    }
    public void LoadNextScene()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        int nextIndex = currentIndex + 1;
        if (doors == 3)
        {
            SceneManager.LoadScene(nextIndex);
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
