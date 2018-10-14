using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
    [SerializeField] Animator animator;


    private void Start()
    {
    }

    private IEnumerator OffBounceAnim()
    {
        yield return new WaitForSeconds(0.01f);
        animator.ResetTrigger("bounce");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && collision.enabled)
        {
            animator.SetTrigger("bounce");
            StartCoroutine(OffBounceAnim());
        }
    }
}
