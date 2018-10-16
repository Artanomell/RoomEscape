using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerAction : MonoBehaviour {

    public UnityEvent action = new UnityEvent();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        action.Invoke();
    }
}
