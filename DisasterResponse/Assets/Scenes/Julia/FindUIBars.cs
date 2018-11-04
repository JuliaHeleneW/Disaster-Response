using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindUIBars : MonoBehaviour {

    public GameObject[] UIBars;
    // Use this for initialization
    void Start () {
        UIBars = GameObject.FindGameObjectsWithTag("UIBar");
        Debug.Log("Size: " + UIBars.Length);
        foreach(GameObject bar in UIBars)
        {
            bar.SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ResetUI()
    {
        foreach (GameObject bar in UIBars)
        {
            bar.GetComponentInChildren<TextDisplay>().onReactivate();
        }
    }
}
