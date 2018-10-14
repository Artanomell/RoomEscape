using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    public static PlayerStats instance;
    #region vars
    [ReadOnly]
    public bool hasKey;
    [ReadOnly]
    public GameObject key;

    public Vector2 lookDirection;

    private Vector3 vecToCenter = new Vector3(0, 0.34f);
    #endregion vars

    // Use this for initialization
    void Start()
    {
        instance = this;
        lookDirection = Vector2.right;
    }

    // Update is called once per frame
    void Update()
    {
        GetLookDirection();
    }

    private void GetLookDirection()
    {
        if (Input.GetAxis("Horizontal") < 0)
            lookDirection = Vector2.left;
        else if (Input.GetAxis("Horizontal") > 0)
            lookDirection = Vector2.right;
    }

    public Vector3 GetObjectCenter()
    {
        return (transform.position + vecToCenter);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(GetObjectCenter(), 0.05f);
    }
}
