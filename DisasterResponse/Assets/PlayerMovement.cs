using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public Sprite[] sprite_list;            // To hold an array of sprites.

    private float speed = 10.0f;
    private bool animate_bool;              // To hold a bool value, determines animation
    private Animator anim;                  // To hold the player's animator component
    private SpriteRenderer sprite_render;   // To hold the player's sprite renderer component
    private Vector2 target;
    private Vector2 position;
    private Camera cam;
	// Use this for initialization
	void Start () {
        animate_bool = false;                               // set animate bool to false
        target = new Vector2(0.0f, 0.0f);
        position = transform.position;
        cam = Camera.main;
        anim = GetComponent<Animator>();                    // set anim to the animator component
        sprite_render = GetComponent<SpriteRenderer>();     // set anim
	}
	
	// Update is called once per frame
	void Update () {
        // Only animate character, if animate bool is true
        if (animate_bool)
        {
            AnimateCharacter();
        }
        float step = speed * Time.deltaTime;

        transform.position = Vector2.MoveTowards(transform.position, target, step);
        //if (Input.GetMouseButtonDown(0))
        //{
        //    MovePlayer();
        //    Debug.Log("Pressed");
        //}

        // If player has reached target, reset animation to false, and animate bool to false
        if(target.x == transform.position.x && target.y == transform.position.y)
        {
            ResetAnimations();
            animate_bool = false;
        }
	}

    /// <summary>
    /// AnimateCharacter method, Determines animations.
    /// </summary>
    private void AnimateCharacter()
    {
        ResetAnimations();
        if (target.x < transform.position.x)
        {
            anim.SetBool("moveLeft", true);
            sprite_render.sprite = sprite_list[3];
        }
        if (target.x > transform.position.x)
        {
            anim.SetBool("moveRight", true);
            sprite_render.sprite = sprite_list[1];
        }
        if (target.y < transform.position.y)
        {
            anim.SetBool("moveDown", true);
            sprite_render.sprite = sprite_list[0];
        }
        if (target.y > transform.position.y)
        {
            anim.SetBool("moveUp", true);
            sprite_render.sprite = sprite_list[2];
        }
    }

    /// <summary>
    /// ResetAnimation method, Resets all animations to false
    /// </summary>
    private void ResetAnimations()
    {
        anim.SetBool("moveLeft", false);
        anim.SetBool("moveRight", false);
        anim.SetBool("moveDown", false);
        anim.SetBool("moveUp", false);
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
            animate_bool = true;    // when on click happens, set animate bool to true
        }
    }
}
