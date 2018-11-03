using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextDisplay : MonoBehaviour {

    public string[] displayTexts;
    private int index;
    private UnityEngine.UI.Text screenText;
    public GameObject image;
    bool textToBeDisplayedLeft;
    // Use this for initialization
    void Start () {
        screenText = GetComponentInChildren<UnityEngine.UI.Text>();
        index = 0;
        //if (displayTexts.Length > 1)
        //{
        //    image.SetActive(true);
        //}
        StartCoroutine(animateText(displayTexts[index]));
        textToBeDisplayedLeft = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (textToBeDisplayedLeft)
        {
            image.SetActive(true);
        }
    }

    public void nextText()
    {
        index++;
        StartCoroutine(animateText(displayTexts[index]));
    }

    IEnumerator animateText(string displayText)
    {
        image.SetActive(false);
        string onScreen = "";
        textToBeDisplayedLeft = false;
        for(int i = 0; i < displayText.Length; i++)
        {
            onScreen += displayText[i];
            screenText.text = onScreen;
            yield return new WaitForSeconds(0.05f);
        }
        if (!(index == displayTexts.Length - 1))
        {
            image.SetActive(true);
        }
    }
}
