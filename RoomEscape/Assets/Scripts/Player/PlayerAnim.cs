using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{

    #region vars
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    private float currVelocityX;
    private float currVelocityY;
    #endregion vars

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        SpriteFlip();
    }

    private void FixedUpdate()
    {
        Animation();
    }

    /// <summary>
    /// Flips sprite in right direction
    /// </summary>
    private void SpriteFlip()
    {
        if (Input.GetAxis("Horizontal") < 0)
            spriteRenderer.flipX = true;
        else if (Input.GetAxis("Horizontal") > 0)
            spriteRenderer.flipX = false;
    }

    /// <summary>
    /// Changes animator states
    /// </summary>
    private void Animation()
    {
        currVelocityX = rb.velocity.x;
        currVelocityY = rb.velocity.y;

        if (GetComponent<Jump>().IsFalling())
            animator.SetBool("Falling", true);
        else animator.SetBool("Falling", false);

        animator.SetFloat("CurrentVelocityX", Math.Abs(currVelocityX));
        animator.SetFloat("CurrentVelocityY", currVelocityY);
    }
}
