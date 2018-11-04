using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteractable : MonoBehaviour {

    public string[] interactItems;
    public GameObject itemDialog;
    public bool startDialogue;

    // Use this for initialization
    void Start () {
        startDialogue = false;
    }
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(itemDialog.GetComponentInChildren<TextDisplay>().toDestroy);
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Worked");
        }
        if ((startDialogue) && (Input.GetMouseButtonDown(1) )&&(itemDialog.GetComponentInChildren<TextDisplay>().toDestroy==false))
        {
            Debug.Log("Why not???");
            GameObject.FindGameObjectWithTag("Player").GetComponent<AltPlayerMovement>().enabled = false;
            startDialogue = false;
            interact();

        }
    }

    public void interact()
    {
        List<Item> items = GameObject.Find("itemManager").GetComponent<Inventory>().items;
        Debug.Log(items.Count);
        int itemCounter = 0;
        for (int i = 0; i < items.Count; i++)
        {
            Debug.Log(items.Count);
            for (int j = 0; j < interactItems.Length; j++)
            {
                Debug.Log(items[i].name);
                Debug.Log(interactItems[j]);
                if (items[i].name==interactItems[j])
                {
                    itemCounter++;
                }
            }
        }
        Debug.Log(itemCounter);
        Debug.Log(interactItems.Length);
        if (itemCounter == interactItems.Length)
        {
            itemDialog.SetActive(true);
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
