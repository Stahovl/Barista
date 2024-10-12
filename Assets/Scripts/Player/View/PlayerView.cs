using UnityEngine;

public class PlayerView : MonoBehaviour
{
    public Animator animator;

    public void UpdateAnimation(bool isMoving)
    {
        print("ismoving = "+isMoving);
        animator.SetBool("IsMoving", isMoving);
    }
}
