using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    bool isFacingRight = true;
    public Animator animator;

    [Header("Movement")]
    public float moveSpeed = 5f;
    float horizontalMovement;

    [Header("Jumping")]
    public float jumpPower = 6f;
    /**
    private bool canDoubleJump = false;
    private int extraJumpsRemaining;
    public int extraJumps = 1;
    */

    [Header("GroundCheck")]
    public Transform groundCheckPos;
    public Vector2 groundCheckSize = new(0.5f, 0.05f);
    public LayerMask groundLayer;

    [Header("Gravity")]
    public float baseGravity = 2;
    public float maxFallSpeed = 18f;
    public float fallSpeedMultiplier = 2f;

    // Start is called before the first frame update
    void Start()
    {
        // Subscribe to the OnCroissantCollected event
        // Croissant.OnCroissantCollected += EnableDoubleJump;
        // Initialize extraJumpsRemaining to the extra jumps
        // extraJumpsRemaining = extraJumps;
    }
    /**
    private void EnableDoubleJump(bool enable)
    {
        // Enable or disable double jump based on the value passed from the event
        canDoubleJump = enable;
        // Debug.Log("Double jump enabled: " + canDoubleJump);
    }
    */

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(horizontalMovement * moveSpeed, rb.velocity.y);
        Gravity();
        Flip();

        animator.SetFloat("yVelocity", rb.velocity.y);
        animator.SetFloat("magnitude", rb.velocity.magnitude);
        if (!IsGrounded())
        {
            animator.SetBool("falling", true);
        }
        else
        {
            animator.SetBool("falling", false);
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        horizontalMovement = context.ReadValue<Vector2>().x;
    }

    public void Jump(InputAction.CallbackContext context)
    {
        // Debug.Log("Jumps remaining: " + extraJumpsRemaining);
        if (IsGrounded()) //|| (canDoubleJump && extraJumpsRemaining > 0))
        {
            if (context.performed)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpPower);
                animator.SetTrigger("jump");
                /**
                if (!IsGrounded() && canDoubleJump)
                {
                    extraJumpsRemaining--;
                }
                */
            }
        }
    }

    private bool IsGrounded()
    {
        if (Physics2D.OverlapBox(groundCheckPos.position, groundCheckSize, 0, groundLayer))
        {
            // extraJumpsRemaining = extraJumps;
            return true;
        }
        return false;
    }

    private void Gravity()
    {
        if (rb.velocity.y < 0)
        {
            rb.gravityScale = baseGravity * fallSpeedMultiplier; // Fall increasingly faster
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Max(rb.velocity.y, -maxFallSpeed));
        }
        else
        {
            rb.gravityScale = baseGravity;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireCube(groundCheckPos.position, groundCheckSize);
    }

    private void Flip()
    {
        if (isFacingRight && horizontalMovement < 0 || !isFacingRight && horizontalMovement > 0)
        {
            isFacingRight = !isFacingRight;
            Vector3 ls = transform.localScale;
            ls.x *= -1f;
            transform.localScale = ls;
        }
    }

}
