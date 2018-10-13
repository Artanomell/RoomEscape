using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public static PlayerStats instance;
    #region vars
    [ReadOnly]
    public bool hasKey;

    private Vector3 vecToCenter = new Vector3(0, 0.34f);
    #endregion vars

    // Use this for initialization
    void Start () {
        instance = this;
    }
	
	// Update is called once per frame
	void Update () {
    }

    public Vector3 GetObjectCenter()
    {
        return (transform.position + vecToCenter);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(GetObjectCenter(), 0.1f);
    }
}
