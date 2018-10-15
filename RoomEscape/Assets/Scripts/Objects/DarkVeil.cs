using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkVeil : MonoBehaviour
{

    public void GoAlpha()
    {
        GetComponent<Animator>().SetTrigger("goAlpha");
    }
}
