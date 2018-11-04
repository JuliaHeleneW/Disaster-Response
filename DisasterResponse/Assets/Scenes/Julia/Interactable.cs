using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {

    public GameObject UIbarDescription;
    public GameObject onSearchPositive;
    public GameObject onSearchNegative;
    public GameObject itemManager;
    public bool isActivated;
    public Item item;
    public bool startDialogue;
    public int timer;


    //public string[] interactItems;
    //public GameObject itemDialog;

    // Use this for initialization
    void Start()
    {
        UIbarDescription.SetActive(false) ;
        isActivated = false;
        startDialogue = false;
        timer = 0;
        //itemManager = GameObject.Find("itemManager");
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
        if (startDialogue&& Input.GetKeyDown(KeyCode.Space) && !(UIbarDescription.GetComponentInChildren<TextDisplay>().toDestroy))
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().enabled = false;
            GameObject.FindGameObjectWithTag("Player").GetComponent<AltPlayerMovement>().enabled = false;
            GameObject.FindGameObjectWithTag("EditorOnly").GetComponent<HintBserver>().isObserverActive = false;
            isActivated = true;
            UIbarDescription.SetActive(true);
            isActivated = false;
            startDialogue = false;
            //interact();
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

    //public void interact()
    //{
    //    List<Item> items = itemManager.GetComponent<Inventory>().items;
    //    int itemCounter=0;
    //    for(int i = 0; i < items.Count; i++)
    //    {
    //        for (int j = 0; j < i; j++)
    //        {
    //            if (items[i].name == interactItems[j])
    //            {
    //                itemCounter++;
    //            }
    //        }
    //    }
    //    if (itemCounter == interactItems.Length)
    //    {
    //        itemDialog.SetActive(true);
    //    }
    //}

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player"&&Input.GetKeyDown(KeyCode.Space)&&!(UIbarDescription.GetComponentInChildren<TextDisplay>().toDestroy))
        {
            UIbarDescription.SetActive(true);
            startDialogue = true;
        }
    }
}
