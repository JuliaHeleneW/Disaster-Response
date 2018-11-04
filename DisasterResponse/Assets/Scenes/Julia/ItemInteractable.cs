using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemInteractable : MonoBehaviour {

    public string[] interactItems;
    public GameObject itemDialog;
    public bool startDialogue;
    public bool haveFlash;
    // Use this for initialization
    void Start () {
        startDialogue = false;
        haveFlash = false;
    }
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(itemDialog.GetComponentInChildren<TextDisplay>().toDestroy);
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Worked");
        }
        //if ((startDialogue) && (Input.GetMouseButtonDown(1) )&&(itemDialog.GetComponentInChildren<TextDisplay>().toDestroy==false))
        //{
        //    Debug.Log("Why not???");
        //    GameObject.FindGameObjectWithTag("Player").GetComponent<AltPlayerMovement>().enabled = false;
        //    startDialogue = false;
        //    interact();

        //}
    }

    public void interact()
    {
        List<Item> items = GameObject.Find("itemManager").GetComponent<Inventory>().items;
        Debug.Log(items.Count);
        int itemCounter = 0;
        for (int i = 0; i < items.Count; i++)
        {
            
                if (items[i].name=="Flashlight")
                {
                    SceneManager.LoadScene("Victory");
                }
        }
        Debug.Log(itemCounter);
        Debug.Log(interactItems.Length);
        if (itemCounter == interactItems.Length)
        {
            itemDialog.SetActive(true);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.transform.tag == "Player" /*&& Input.GetMouseButtonDown(1) && itemDialog.GetComponentInChildren<TextDisplay>().toDestroy == false*/)
        {
            Debug.Log("Why???");
            interact();
            Debug.Log("???");
            startDialogue = true;
            GameObject.FindGameObjectWithTag("Player").GetComponent<AltPlayerMovement>().enabled = false;
            startDialogue = false;
            //interact();
        }
        //if (startDialogue && Input.GetMouseButtonDown(1) && itemDialog.GetComponentInChildren<TextDisplay>().toDestroy == false)
        //{
        //    Debug.Log("Why not???");
        //    GameObject.FindGameObjectWithTag("Player").GetComponent<AltPlayerMovement>().enabled = false;
        //    startDialogue = false;
        //    interact();
        //}
        //if (Input.GetMouseButtonDown(0) && !(UIbarDescription.GetComponentInChildren<TextDisplay>().toDestroy))
        //{
        //    Debug.Log("Why???");
        //    startDialogue = true;
        //}
    }
}
