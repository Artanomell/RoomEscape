using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{

    public float speed = 1;
    [SerializeField] private GameObject SpritesParent;
    [SerializeField] private bool followPlayer;

    private Animator animator;

    // Use this for initialization
    void Start()
    {
        animator = SpritesParent.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (followPlayer)
        {
            FollowPlayer();
        }
    }

    private void FollowPlayer()
    {
        if (Vector2.Distance(transform.position, PlayerStats.instance.transform.position) > 1f)
        {
            Vector3 heading = transform.position - PlayerStats.instance.GetObjectCenter();
            float distance = heading.magnitude;
            Vector3 direction = heading / distance;

            float speed = this.speed * Vector2.Distance(transform.position, PlayerStats.instance.GetObjectCenter());

            transform.position -= direction.normalized * Time.deltaTime * speed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (!PlayerStats.instance.hasKey)
            {
                PlayerStats.instance.hasKey = true;
                followPlayer = true;
                animator.Play("key_pop");
            }
        }
    }
}
