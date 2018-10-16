using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxMagnitude : MonoBehaviour
{

    public float maxMagnitude = 12;
    private Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        LimitMagnitude();
    }

    /// <summary>
    /// Limits Rigidody2D magnitude
    /// </summary>
    private void LimitMagnitude()
    {
        // Trying to Limit Speed
        if (rb.velocity.magnitude > maxMagnitude)
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxMagnitude);
        }
    }
}
