using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    public ButtonScript buttonScript;
    [SerializeField] private Animator animator;

    void Update()
    {
        if (buttonScript.flagOnButton == 1)
        {
            animator.SetBool("isOnButton", true);
        }
        else
        {
            animator.SetBool("isOnButton", false);
        }
    }
}
