using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {

    public GameObject UIbarDescription;
    public GameObject onSearchPositive;
    public GameObject onSearchNegative;
    public bool isActivated;
    public Item item;
    public bool startDialogue;

    // Use this for initialization
    void Start()
    {
        UIbarDescription.SetActive(false) ;
        isActivated = false;
        startDialogue = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown(0)&&!UIbarDescription.GetComponentInChildren<TextDisplay>().toDestroy)
        //{
        //    isActivated = true;
        //}
        if (isActivated)
        {
            UIbarDescription.SetActive(true);
            isActivated = false;
        }
        if (startDialogue&& Input.GetMouseButtonDown(0) && !(UIbarDescription.GetComponentInChildren<TextDisplay>().toDestroy))
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<AltPlayerMovement>().enabled = false;
            isActivated = true;
            UIbarDescription.SetActive(true);
            isActivated = false;
            startDialogue = false;
        }
    }

    //private void OnMouseDown()
    //{
    //    if (Input.GetKey("mouse 0")&&!(UIbarDescription.GetComponentInChildren<TextDisplay>().toDestroy))
    //    {
    //        Debug.Log("Box Clicked Bed!");
    //        isActivated = true;
    //        UIbarDescription.SetActive(true);
    //        isActivated = false;
    //    }
    //}

    //functionality for button
    public void search()
    {
        if(item==null)
        {
            onSearchNegative.gameObject.SetActive(true);
        }
        if (item != null)
        {
            onSearchPositive.gameObject.SetActive(true);
        }
    }

    public void pickup()
    {
        if (item != null)
        {
            Debug.Log(GameObject.Find("itemManager").name);
            GameObject.Find("itemManager").GetComponent<Inventory>().Add(item);
            item = null;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            Debug.Log("Why???");
            startDialogue = true;
        }
        //if (Input.GetMouseButtonDown(0) && !(UIbarDescription.GetComponentInChildren<TextDisplay>().toDestroy))
        //{
        //    Debug.Log("Why???");
        //    startDialogue = true;
        //}
    }
}
