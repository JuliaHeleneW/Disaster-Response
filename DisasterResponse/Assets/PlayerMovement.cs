using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private float speed = 10.0f;
    private Vector2 target;
    private Vector2 position;
    private Camera cam;
	// Use this for initialization
	void Start () {
        target = new Vector2(0.0f, 0.0f);
        position = transform.position;
        cam = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
        float step = speed * Time.deltaTime;

        transform.position = Vector2.MoveTowards(transform.position, target, step);
        //if (Input.GetMouseButtonDown(0))
        //{
        //    MovePlayer();
        //    Debug.Log("Pressed");
        //}
	}

    private void OnGUI()
    {
        Event currentEvent = Event.current;
        Vector2 mousePos = new Vector2();
        Vector2 point = new Vector2();

        mousePos.x = currentEvent.mousePosition.x;
        mousePos.y = cam.pixelHeight - currentEvent.mousePosition.y;
        point = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 0.0f));
        if(Input.GetMouseButtonDown(0))
        {
            target = point;
        }
    }
}
