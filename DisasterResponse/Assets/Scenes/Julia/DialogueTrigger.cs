using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

    public GameObject UIbar;
    public bool isActivated;
	// Use this for initialization
	void Start () {
        UIbar.SetActive(false);
        isActivated = false;
	}
	
	// Update is called once per frame
	void Update () {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    isActivated = true;
        //}
        //if (isActivated)
        //{
        //    UIbar.SetActive(true);
        //}
	}

    //functionality for button
    void pickUp()
    {
        isActivated = true;
    }
}
