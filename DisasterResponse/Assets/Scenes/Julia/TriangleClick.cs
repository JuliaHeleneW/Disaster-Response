using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleClick : MonoBehaviour {
    public TextDisplay parentReference;

    private void Start()
    {
        parentReference = transform.parent.parent.parent.GetComponent<TextDisplay>();
        Debug.Log(transform.parent.GetChild(0));
    }

    private void Update()
    {
        if (Input.GetKey("mouse 0"))
        {
            Debug.Log("Box Clicked!");
            parentReference.nextText();
        }
    }
    //private void OnMouseOver()
    //{
    //    if (parentReference.image.activeSelf == true && Input.GetMouseButtonDown(0))
    //    {
    //        parentReference.nextText();
    //    }
    //}

    private void OnMouseOver()
    {
        if (Input.GetKey("mouse 0"))
        {
            Debug.Log("Box Clicked!");
            parentReference.nextText();
        }
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        Debug.Log("Box Clicked!");
    //        parentReference.nextText();
    //    }
    //}
}
