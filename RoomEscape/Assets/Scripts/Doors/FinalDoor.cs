using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FinalDoor : MonoBehaviour
{

    #region vars
    [SerializeField] Sprite doorOpenedSprite;
    [SerializeField] Sprite doorClosedSprite;

    public bool isOpened;
    public float radius = 1;
    public LayerMask whoIsPlayer;
    public UnityEvent enterDoor = new UnityEvent();

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
            {
                if (CheckIsPlayerNearDoor())
                {
                    enterDoor.Invoke();
                }
            }
        }
    }

    private void TryToOpen()
    {
        // Check if the player is near the door and does he has the key
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
        Collider2D[] colls = Physics2D.OverlapCircleAll(transform.position, radius, whoIsPlayer);

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

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;

        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
