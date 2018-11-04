using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltPlayerMovement : MonoBehaviour {
    public Sprite[] sprite_list;

    private float speed;
    private bool moveLeft;
    private bool moveRight;
    private bool moveUp;
    private bool moveDown;
    private Animator anim;
    private SpriteRenderer sprite_render;
    private Camera cam;

    // Use this for initialization
    void Start () {
        moveLeft = false;
        moveRight = false;
        moveUp = false;
        moveDown = false;
        speed = 0.1f;
        cam = Camera.main;
        anim = GetComponent<Animator>();
        sprite_render = GetComponent<SpriteRenderer>();
	}

    // Update is called once per frame
    void Update () {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        // walking, enable animator, move player, and play animation
        if (Input.GetKey(KeyCode.A) && !moveRight && !moveUp && !moveDown)
        {
            anim.enabled = true;
            transform.Translate(Vector2.left * speed);
            anim.Play("move_left");
            moveLeft = true;
        }
        if (Input.GetKey(KeyCode.D) && !moveLeft && !moveUp && !moveDown)
        {
            anim.enabled = true;
            transform.Translate(Vector2.right * speed);
            anim.Play("move_right");
            moveRight = true;
        }
        if (Input.GetKey(KeyCode.S) && !moveRight && !moveUp && !moveLeft)
        {
            anim.enabled = true;
            transform.Translate(Vector2.down * speed);
            anim.Play("move_down");
            moveDown = true;
        }
        if (Input.GetKey(KeyCode.W) && !moveRight && !moveLeft && !moveDown)
        {
            anim.enabled = true;
            transform.Translate(Vector2.up * speed);
            anim.Play("move_up");
            moveUp = true;
        }


        // When key is up, disable animator, and set the sprite for the spefic image
        if (Input.GetKeyUp(KeyCode.A) && moveLeft)
        {
            anim.enabled = false;
            sprite_render.sprite = sprite_list[3];
            moveLeft = false;
        }
        if (Input.GetKeyUp(KeyCode.D) && moveRight)
        {
            anim.enabled = false;
            sprite_render.sprite = sprite_list[1];
            moveRight = false;
        }
        if (Input.GetKeyUp(KeyCode.S) && moveDown)
        {
            anim.enabled = false;
            sprite_render.sprite = sprite_list[0];
            moveDown = false;
        }
        if (Input.GetKeyUp(KeyCode.W) && moveUp)
        {
            anim.enabled = false;
            sprite_render.sprite = sprite_list[2];
            moveUp = false;
        }
    }
}
