using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintBserver : MonoBehaviour {
    // To hold boolean values for events to listen for
    public bool parentsDoor;       // To hold parent door bool
    public bool callHelp;          // To hold call help bool
    public bool putOutFire;        // To hold put out fire bool
    private bool parentsDoorCheck;  
    private bool callHelpCheck;     
    private bool putOutFireCheck;   
    public bool isObserverActive;  // To hold active
    private int caseIndex;          // To hold switch case b
    private int hint_timer;         // To hold hint timer

    public GameObject parentsDialog;
    public GameObject helpDialog;
    public GameObject fireDialog;

    // Use this for initialization
    void Start () {
        isObserverActive = true;
        parentsDoor = true;
        callHelp = true;
        putOutFire = true;
        parentsDoorCheck = false;
        callHelpCheck = false;
        putOutFireCheck = false;
        caseIndex = 0;
        hint_timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (isObserverActive)
        {
            hint_timer++;

            if (!parentsDoor && !parentsDoorCheck)
            {
                Debug.Log("Achievement 01: During fire, checking doors for temperature can prevent damage yourself.");
                parentsDoorCheck = true;
            }
            if (!callHelp && !callHelpCheck)
            {
                Debug.Log("Achievement 02: First responder! Calling for help is crucial to saving lives quicker.");
                callHelpCheck = true;
            }
            if (!putOutFire && !putOutFireCheck)
            {
                Debug.Log("Achievement 03: If fire is strong, and you can't escape, look for sources to put fire out");
                putOutFireCheck = true;
            }
        }

        if (hint_timer > 3600 && caseIndex < 2 && isObserverActive)
        {
            DisplayHint(caseIndex);
            hint_timer = 0;
        }
	}

    private void DisplayHint(int num)
    {
        switch (num)
        {
            case 0:
                if (parentsDoor)
                {
                    Debug.Log("Parents door hint displays");
                    parentsDialog.SetActive(true);
                }
                break;
            case 1:
                if (callHelp)
                {
                    Debug.Log("call for help hint displays");
                    helpDialog.SetActive(true);
                }
                break;
            case 2:
                if (putOutFire)
                {
                    Debug.Log("put out fire hint displays");
                    fireDialog.SetActive(true);
                }
                break;
        }
        caseIndex++;
    }

    public void ParentsDoor()
    {
        parentsDoor = false;
    }
    public void CallHelp()
    {
        callHelp = false;
    }
    public void PutOutFire()
    {
        putOutFire = false;
    }
    public void PauseObserver()
    {
        isObserverActive = false;
    }
    public void PlayObserver()
    {
        isObserverActive = true;
    }
}
