using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayDeathAnim()
    {
        animator.SetTrigger("Die");
    }
}
