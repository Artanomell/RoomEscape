using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalDoor : MonoBehaviour {

    #region vars
    [SerializeField] Sprite doorOpenedSprite;
    [SerializeField] Sprite doorClosedSprite;

    public bool isOpened;
    #endregion vars

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "MainKey")
        {
            isOpened = true;
        }
    }
}
