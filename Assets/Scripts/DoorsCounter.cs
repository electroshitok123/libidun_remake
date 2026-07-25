using UnityEngine;

public class DoorsCounter : MonoBehaviour
{
    public int doors;

    public void AddScore(int amount)
    {
        doors += amount;
    }

    public void RemoveScore(int amount)
    {
        doors -= amount;
    }
}
