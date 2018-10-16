using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayBlock : MonoBehaviour
{

    [SerializeField] Animator animator;


    private IEnumerator OffBounceAnim()
    {
        yield return new WaitForSeconds(0.01f);
        animator.ResetTrigger("interact");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.enabled)
        {
            animator.SetTrigger("interact");
            StartCoroutine(OffBounceAnim());
        }
    }
}
