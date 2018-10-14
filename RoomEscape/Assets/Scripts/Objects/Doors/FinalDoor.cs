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
    public UnityEvent enterDoor = new UnityEvent();

    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private bool isPlayerNearDoor;
    #endregion vars


    // Use this for initialization
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
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
                if (isPlayerNearDoor)
                {
                    enterDoor.Invoke();
                }
            }
        }
    }

    private void TryToOpen()
    {
        // Check if the player is near the door and does he has the key
        if (isPlayerNearDoor && CheckIsHasKey())
            OpenDoor();
    }

    private void OpenDoor()
    {
        isOpened = true;
        PlayerStats.instance.hasKey = false;
        Destroy(PlayerStats.instance.key);
        spriteRenderer.sprite = doorOpenedSprite;
        animator.SetTrigger("pop");
        StartCoroutine(OffPopAnim());
    }

    private bool CheckIsHasKey()
    {
        return PlayerStats.instance.hasKey;
    }


    private IEnumerator OffPopAnim()
    {
        yield return new WaitForSeconds(0.01f);
        animator.ResetTrigger("pop");
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Player")
        {
            isPlayerNearDoor = true;
        }
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.tag == "Player")
        {
            isPlayerNearDoor = false;
        }
    }
}
