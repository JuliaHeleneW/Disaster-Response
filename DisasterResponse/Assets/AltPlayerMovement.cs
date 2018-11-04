using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltPlayerMovement : MonoBehaviour {
    public Sprite[] sprite_list;

    private float speed;
    private Animator anim;
    private SpriteRenderer sprite_render;
    private Camera cam;

    // Use this for initialization
    void Start () {
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
        if (Input.GetKey(KeyCode.A))
        {
            anim.enabled = true;
            transform.Translate(Vector2.left * speed);
            anim.Play("move_left");
        }
        if (Input.GetKey(KeyCode.D))
        {
            anim.enabled = true;
            transform.Translate(Vector2.right * speed);
            anim.Play("move_right");
        }
        if (Input.GetKey(KeyCode.S))
        {
            anim.enabled = true;
            transform.Translate(Vector2.down * speed);
            anim.Play("move_down");
        }
        if (Input.GetKey(KeyCode.W))
        {
            anim.enabled = true;
            transform.Translate(Vector2.up * speed);
            anim.Play("move_up");
        }


        // When key is up, disable animator, and set the sprite for the spefic image
        if (Input.GetKeyUp(KeyCode.A))
        {
            anim.enabled = false;
            sprite_render.sprite = sprite_list[3];
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            anim.enabled = false;
            sprite_render.sprite = sprite_list[1];
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            anim.enabled = false;
            sprite_render.sprite = sprite_list[0];
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            anim.enabled = false;
            sprite_render.sprite = sprite_list[2];
        }
    }
}
