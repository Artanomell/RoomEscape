using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region vars
    public float speed = 300;

    [SerializeField] private LayerMask obstacleMask;

    private Rigidbody2D rb;
    private float currSpeed;
    private Vector2 sidesCheckRay = new Vector2(0, 0.32f);
    private Vector2 spriteCenter = new Vector2(0, 0.33f);
    private float distanceToWall = 0.33f;
    #endregion vars

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckObstacles();
        Movement();
    }

    /// <summary>
    /// Moves player object 
    /// </summary>
    private void Movement()
    {
        float h = HyperInput.instance.GetAxis("Horizontal");
        currSpeed = h * speed;

        rb.velocity = new Vector2(currSpeed * Time.deltaTime, rb.velocity.y);
    }
    

    /// <summary>
    /// Limits axis input value
    /// </summary>
    private void CheckObstacles()
    {
        if (!IsBlockedWay(Vector2.right))
            HyperInput.instance.LimitAxis("Horizontal", ValueLimitType.UnlockAboveZero);
        else
            HyperInput.instance.LimitAxis("Horizontal", ValueLimitType.LockAboveZero);


        if (!IsBlockedWay(Vector2.left))
            HyperInput.instance.LimitAxis("Horizontal", ValueLimitType.UnlockBelowZero);
        else
            HyperInput.instance.LimitAxis("Horizontal", ValueLimitType.LockBelowZero);
    }

    /// <summary>
    /// Returns true, if there is exists obstacle in the direction of @side
    /// </summary>
    /// <param name="side"></param>
    /// <returns></returns>
    private bool IsBlockedWay(Vector2 side)
    {
        if (!Physics2D.Raycast((Vector2)transform.position + spriteCenter, side, distanceToWall, obstacleMask)
               && !Physics2D.Raycast((Vector2)transform.position + spriteCenter + sidesCheckRay, side, distanceToWall, obstacleMask)
               && !Physics2D.Raycast((Vector2)transform.position + spriteCenter - sidesCheckRay, side, distanceToWall, obstacleMask))
            return false;
        else return true;
    }


    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay((Vector2)transform.position + spriteCenter, Vector2.right * distanceToWall);
        Gizmos.DrawRay((Vector2)transform.position + spriteCenter + sidesCheckRay, Vector2.right * distanceToWall);
        Gizmos.DrawRay((Vector2)transform.position + spriteCenter - sidesCheckRay, Vector2.right * distanceToWall);

        Gizmos.DrawRay((Vector2)transform.position + spriteCenter, Vector2.left * distanceToWall);
        Gizmos.DrawRay((Vector2)transform.position + spriteCenter + sidesCheckRay, Vector2.left * distanceToWall);
        Gizmos.DrawRay((Vector2)transform.position + spriteCenter - sidesCheckRay, Vector2.left * distanceToWall);
    }
}
