using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    public bool lookAtTarget;


    void FixedUpdate()
    {
        Vector3 desiredPosition;
        desiredPosition = target.position + offset;

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;


        if (lookAtTarget)
            transform.LookAt(target);
        else transform.rotation = Quaternion.Euler(Vector3.zero);
    }
}
