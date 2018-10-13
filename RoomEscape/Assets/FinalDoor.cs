using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalDoor : MonoBehaviour
{

    #region vars
    [SerializeField] Sprite doorOpenedSprite;
    [SerializeField] Sprite doorClosedSprite;

    public bool isOpened;
    public float radius = 1;

    private SpriteRenderer spriteRenderer;
    #endregion vars

    // Use this for initialization
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isOpened)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
                TryToOpen();
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
                Debug.Log("VOSHEL");
            // TODO: Level transition script
        }
    }

    private void TryToOpen()
    {
        // Check if the player is near the door
        if (CheckIsPlayerNearDoor() && CheckIsHasKey())
            OpenDoor();

    }

    private void OpenDoor()
    {
        isOpened = true;
        spriteRenderer.sprite = doorOpenedSprite;
    }

    private bool CheckIsHasKey()
    {
        return PlayerStats.instance.hasKey;
    }

    private bool CheckIsPlayerNearDoor()
    {
        Collider2D[] colls = Physics2D.OverlapCircleAll(transform.position, radius);
        foreach (Collider2D coll in colls)
        {
            if (coll.tag == "Player")
            {
                return true;
            }
            else return false;
        }

        return false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "MainKey")
        {
            isOpened = true;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;

        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
