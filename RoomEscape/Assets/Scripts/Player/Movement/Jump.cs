using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    #region vars
    public float jumpForce = 43;
    public LayerMask groundMask;
    public float distanceToGround = 0.05f;
    [Tooltip("The vector that is uses to set the ground check rays on the edges of the player object.")]
    public Vector2 sideGroundCheckRay = new Vector2(0.285f, 0);
    [Tooltip("How much time does player get to jump right after he stepped off of the platform?")]
    public float coyoteTime = 0.2f;
    public bool isJumped { get; private set; }  // Is player has jumped already
    

    private Rigidbody2D rb;
    private bool jumpRequest;       // Uses to call DoJump() in FixedUpdate
    #endregion vars

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(AbyssJumpCoyoteTime());
    }


    // Update is called once per frame
    void Update()
    {
        if (isGrounded())
            if (Input.GetButtonDown("Jump"))
            {
                jumpRequest = true;
            }

        AbyssJumpCoyoteTime();
    }

    private void FixedUpdate()
    {
        if (jumpRequest)
        {
            DoJump();
        }
    }

    

    public void DoJump()
    {
        isJumped = true;
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        jumpRequest = false;
    }


    public bool isGrounded()
    {
        // Checking ground right under the center of the player object.
        if (Physics2D.Raycast((Vector2)transform.position, Vector2.down, distanceToGround, groundMask))
        {
            isJumped = false;
            if (HyperInput.instance.InputBufferContains("Jump"))
                jumpRequest = true;

            return true;
        }   // Checking ground under the right edge of the player object.
        else if (Physics2D.Raycast((Vector2)transform.position + sideGroundCheckRay, Vector2.down, distanceToGround, groundMask))
        {
            isJumped = false;

            if (HyperInput.instance.InputBufferContains("Jump"))
                jumpRequest = true;

            return true;
        }   // Checking ground under the left edge of the player object.
        else if (Physics2D.Raycast((Vector2)transform.position - sideGroundCheckRay, Vector2.down, distanceToGround, groundMask))
        {
            isJumped = false;

            if (HyperInput.instance.InputBufferContains("Jump"))
                jumpRequest = true;

            return true;
        }
        else return false;  // Else player object is not on the ground.
    }

    public bool IsFalling()
    {
        if (!isGrounded())
        {
            if (rb.velocity.y < 0)
                return true;
        }

        return false;
    }

    public void SetCoyoteTime(int time)
    {
        coyoteTime = time;
    }

    /// <summary>
    /// For a few frames player get opportunity to jump right after he stepped off of the platform.
    /// </summary>
    IEnumerator AbyssJumpCoyoteTime()
    {
        float i = 0;
        bool wasOnGround = isGrounded();
        bool OnGround = isGrounded();
        yield return new WaitForSeconds(1);

        while (true)
        {
            OnGround = isGrounded();

            if (wasOnGround && !OnGround && !isJumped)
            {
                while (true)
                {
                    if (i >= coyoteTime)
                    {
                        i = 0;
                        break;
                    }

                    if (HyperInput.instance.InputBufferContains("Jump"))
                    {
                        jumpRequest = true;
                        i = 0;
                        break;
                    }

                    i += 0.01f;
                    yield return new WaitForSeconds(0.01f);
                }
            }

            wasOnGround = OnGround;
            yield return new WaitForSeconds(0.01f);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay((Vector2)transform.position, Vector2.down * distanceToGround);
        Gizmos.DrawRay((Vector2)transform.position + sideGroundCheckRay, Vector2.down * distanceToGround);
        Gizmos.DrawRay((Vector2)transform.position - sideGroundCheckRay, Vector2.down * distanceToGround);
    }
}
