using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openDoor : MonoBehaviour {
    public GameObject door;
	// Use this for initialization
	void Start () {
        //door.SetActive(true);
	}
	
    public void disableDoor()
    {
        door.GetComponent<SpriteRenderer>().enabled = false;
        door.GetComponent<BoxCollider2D>().enabled = false;
    }
	// Update is called once per frame
	void Update () {
        
	}
}
