using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unfader : MonoBehaviour
{

    public void GoAlpha()
    {
        GetComponent<Animator>().SetTrigger("goAlpha");
    }
}
