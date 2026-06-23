using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private Rigidbody2D rb;
    private bool moving = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void AnimateMovement(Vector2 input)
    {
        if (input.magnitude > 0.1f || input.magnitude < -0.1f)
        {
            moving = true;
        }
        else
        {
            moving = false;
        }

        if (moving)
        {
            animator.SetFloat("SpeedX", input.x);
            animator.SetFloat("SpeedY", input.y);
        }

        animator.SetBool("Moving", moving);
    }

    public void PlayDeathAnim()
    {
        animator.SetTrigger("Die");
    }
}
