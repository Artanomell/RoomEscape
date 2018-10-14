using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Jump))]
public class JumpCurve : MonoBehaviour
{
    public float fallMutiplier = 2.5f;
    public float lowJumpMutiplier = 10f;
    public float booster = 1.5f;
    public float gravity = 2.2f;

    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if ((rb.velocity.y) < 0)
        {
            rb.gravityScale = fallMutiplier * booster;
        }
        else if ((rb.velocity.y) < 0)
        {
            rb.gravityScale = fallMutiplier;
        }
        else if (rb.velocity.y >= 0 && !Input.GetButton("Jump"))
        {
            rb.gravityScale = lowJumpMutiplier;
        }
        else
        {
            rb.gravityScale = gravity;
        }
    }
}