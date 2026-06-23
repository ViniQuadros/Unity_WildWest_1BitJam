using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float sprintSpeed = 10f;

    private float movementSpeed;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private bool canMove = true;
    private bool canRun = false;
    private PlayerAnimations playerAnim;
    [SerializeField] private SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<PlayerAnimations>();

        movementSpeed = walkSpeed;
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            rb.linearVelocity = moveInput * movementSpeed;
        }
    }

    public void SetCanMove(bool move)
    {
        canMove = move;

        if (!canMove)
        {
            moveInput = Vector2.zero;
            rb.linearVelocity = Vector2.zero;
        }
    }

    public void AllowRunning()
    {
        canRun = true;
    }

    private void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();

        if (canMove)
        {
            playerAnim.AnimateMovement(moveInput);

            if (moveInput.x < 0) 
                spriteRenderer.flipX = true;
            if (moveInput.x > 0) 
                spriteRenderer.flipX = false;
        }
    }

    private void OnSprint(InputValue value)
    {
        if (canRun)
        {
            movementSpeed = value.isPressed ? sprintSpeed : walkSpeed;
        }
    }
}
