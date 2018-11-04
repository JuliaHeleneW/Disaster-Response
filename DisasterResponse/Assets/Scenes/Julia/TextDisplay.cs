using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextDisplay : MonoBehaviour
{

    public string[] displayTexts;
    public GameObject choiceBox;
    public int index;
    private UnityEngine.UI.Text screenText;
    public GameObject image;
    bool textToBeDisplayedLeft;
    public bool toDestroy;
    public bool coroutine_running;
    // Use this for initialization
    void Start()
    {
        screenText = GetComponentInChildren<UnityEngine.UI.Text>();
        index = 0;
        StartCoroutine(animateText(displayTexts[index]));
        textToBeDisplayedLeft = false;
        toDestroy = false;
        coroutine_running = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (textToBeDisplayedLeft)
        {
            image.SetActive(true);
        }
        if (toDestroy && Input.GetMouseButtonDown(0))
        {
            transform.parent.gameObject.SetActive(false);
            if (this.gameObject.transform.tag == "Ending" && this.gameObject.activeSelf == true && toDestroy)
            {
                transform.parent.parent.gameObject.GetComponent<FindUIBars>().ResetUI();
                GameObject.FindGameObjectWithTag("Player").GetComponent<AltPlayerMovement>().enabled = true;
            }
        }
        if (!toDestroy&&this.gameObject.activeSelf && !coroutine_running)
        {
            StartCoroutine(animateText(displayTexts[index]));
        }
    }

    public void onReactivate()
    {
        screenText = GetComponentInChildren<UnityEngine.UI.Text>();
        index = 0;
        //StartCoroutine(animateText(displayTexts[index]));
        textToBeDisplayedLeft = false;
        toDestroy = false;
    }

    public void nextText()
    {
        index++;
        StartCoroutine(animateText(displayTexts[index]));
    }


    IEnumerator animateText(string displayText)
    {
        coroutine_running = true;
        image.SetActive(false);
        string onScreen = "";
        textToBeDisplayedLeft = false;
        for (int i = 0; i < displayText.Length; i++)
        {
            onScreen += displayText[i];
            screenText.text = onScreen;
            yield return new WaitForSeconds(0.05f);
        }
        if (!(index == displayTexts.Length - 1))
        {
            image.SetActive(true);
        }
        else
        {
            if (choiceBox != null)
            {
                yield return new WaitForSeconds(1f);
                choiceBox.SetActive(true);
            }
            toDestroy = true;
            index = 0;
            coroutine_running = false;
        }
    }
}