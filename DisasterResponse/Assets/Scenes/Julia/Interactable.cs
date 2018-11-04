using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {

    public GameObject UIbarDescription;
    public GameObject onSearchPositive;
    public GameObject onSearchNegative;
    public bool isActivated;
    public Item item;
    // Use this for initialization
    void Start()
    {
        UIbarDescription.SetActive(false) ;
        isActivated = false;
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
    }

    private void OnMouseDown()
    {
        if (Input.GetKey("mouse 0")&&!(UIbarDescription.GetComponentInChildren<TextDisplay>().toDestroy))
        {
            Debug.Log("Box Clicked!");
            isActivated = true;
            UIbarDescription.SetActive(true);
            isActivated = false;
        }
    }

    //functionality for button
    public void search()
    {
        if (item != null)
        {
            onSearchPositive.gameObject.SetActive(true);
        }
        else
        {
            onSearchNegative.gameObject.SetActive(true);
        }
    }

    public void pickup()
    {
        if (item != null)
        {
            GameObject.Find("ItemManager").GetComponent<Inventory>().Add(item);
            item = null;
        }
    }
}
