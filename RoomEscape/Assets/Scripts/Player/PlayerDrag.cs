using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDrag : MonoBehaviour
{
    public float ThrowForce = 10;
    public Transform putBackArea;
    public Vector2 areaDragSizeVec;
    [ReadOnly]
    public bool isDragging;
    [ReadOnly]
    public GameObject draggedObj;
    [ReadOnly]
    public GameObject draggedObjFake;
    public LayerMask whatIsObstacle;
    public LayerMask whatIsDraggable;

    private SpriteRenderer spriteRenderer;


    // Update is called once per frame
    void Update()
    {
        if (!isDragging)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                Drag();
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                Throw();
            }
        }
    }

    private void Drag()
    {
        Collider2D[] colls = Physics2D.OverlapBoxAll(transform.position, areaDragSizeVec, 0, whatIsDraggable);

        foreach (Collider2D coll in colls)
        {
            if (coll.tag == "DraggableObj")
            {
                // yay, we dragging obj now
                isDragging = true;

                // We will turn off real dragged obj and show the same fake obj to player,
                // It will help us to not turn off colliders and rigidbodies of the real object.

                // draggedObj - real object
                draggedObj = coll.gameObject;
                // draggedObjFake - fake object, player will see it instead of real obj
                draggedObjFake = new GameObject("DraggableObj");
                draggedObjFake.transform.position = gameObject.transform.position;

                // Adding sprite renderer to fake obj
                draggedObjFake.AddComponent<SpriteRenderer>();
                spriteRenderer = draggedObjFake.GetComponent<SpriteRenderer>();

                // Set fake obj scale to real obj scale
                draggedObjFake.transform.localScale = draggedObj.transform.localScale;
                // Set fake obj sprite and color to sprite and color of the real obj
                spriteRenderer.sprite = draggedObj.GetComponent<DraggableObj>().spriteRenderer.sprite;
                spriteRenderer.color = draggedObj.GetComponent<DraggableObj>().spriteRenderer.color;
                spriteRenderer.sortingOrder = draggedObj.GetComponent<DraggableObj>().spriteRenderer.sortingOrder;

                // Set fake obj child of this gameobject
                draggedObjFake.transform.parent = gameObject.transform;

                // Turning off the real object
                draggedObj.SetActive(false);
                return;
            }
        }
    }

    private void Throw()
    {
        Collider2D[] colls = Physics2D.OverlapBoxAll(transform.position, areaDragSizeVec, 0, whatIsObstacle);

        // Check is there obstacle in the place of throwing the object
        // If there is no obstacles
        if (colls.Length == 0)
        {
            // Throw in front of player

            isDragging = false;

            Destroy(draggedObjFake);
            draggedObjFake = null;

            draggedObj.SetActive(true);
            draggedObj.transform.position = gameObject.transform.position;
            draggedObj.GetComponent<Rigidbody2D>().AddForce((PlayerStats.instance.lookDirection + Vector2.up) * ThrowForce,
                ForceMode2D.Impulse);
            draggedObj = null;
        }
        /*  else // If there is some obstacle
          {

              // Put object behind player
              isDragging = false;

              Destroy(draggedObjFake);
              draggedObjFake = null;

              draggedObj.SetActive(true);
              draggedObj.transform.position = putBackArea.position;
              draggedObj = null;
          }*/
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, areaDragSizeVec);
    }
}
