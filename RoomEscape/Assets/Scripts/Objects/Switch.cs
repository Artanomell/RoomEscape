using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Switch : MonoBehaviour
{
    public float areaSize;
    public LayerMask whoIsPlayer;
    public UnityEvent OnSwitch = new UnityEvent();

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (IsPlayerNear())
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                OnSwitch.Invoke();
            }
        }
    }

    bool IsPlayerNear()
    {
        Collider2D[] colls = Physics2D.OverlapCircleAll(transform.position, areaSize, whoIsPlayer);

        foreach (Collider2D coll in colls)
        {
            if (coll.tag == "Player")
            {
                return true;
            }
        }

        return false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(transform.position, areaSize);
    }
}
