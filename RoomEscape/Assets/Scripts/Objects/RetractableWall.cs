using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetractableWall : MonoBehaviour
{
    public float speed = 1;
    public Vector3 openVec;
    public Vector3 closeVec;
    public bool canClose;


    [SerializeField] private bool isMoving;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void MoveWall(SpriteRenderer switchSpriteRenderer)
    {
        if (!isMoving)
            if (Vector2.Distance(transform.position, closeVec) <= 0.5f)
            {
                switchSpriteRenderer.flipX = !switchSpriteRenderer.flipX;
                StartCoroutine(MoveTo(openVec));
            }
            else if (canClose && Vector2.Distance(transform.position, openVec) <= 0.5f)
            {
                switchSpriteRenderer.flipX = !switchSpriteRenderer.flipX;
                StartCoroutine(MoveTo(closeVec));
            }
    }


    private IEnumerator MoveTo(Vector3 vec)
    {
        isMoving = true;

        while (Vector2.Distance(transform.position, vec) >= 0.05f)
        {
            yield return null;
            Vector3 heading = transform.position - vec;
            float distance = heading.magnitude;
            Vector3 direction = (heading / distance).normalized;
            transform.position -= direction * Time.deltaTime * speed;
        }

        transform.position = vec;

        isMoving = false;
    }
}
