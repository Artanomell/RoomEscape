using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DelayAction : MonoBehaviour
{

    public float delayTime = 3;
    public UnityEvent action = new UnityEvent();

    // Use this for initialization
    void Start()
    {
        StartCoroutine(DoDelayAction());
    }

    IEnumerator DoDelayAction()
    {
        yield return new WaitForSeconds(delayTime);
        action.Invoke();
    }
}
