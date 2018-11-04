using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltPlayerMovement : MonoBehaviour {
    public Sprite[] sprite_list;

    private float speed = 0.1f;
    private bool animate_bool;
    private bool moveLeft;
    private bool moveRight;
    private bool moveUp;
    private bool moveDown;
    private Animator anim;
    private SpriteRenderer sprite_render;
    private Vector2 position;
    private Camera cam;
    private Vector2 move;
    private GameObject player;
    private bool collided = false;
    //public Transform target;
    // Use this for initialization
    void Start () {
        animate_bool = false;
        //move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        cam = Camera.main;
        anim = GetComponent<Animator>();
        sprite_render = GetComponent<SpriteRenderer>();
	}

    // Update is called once per frame
    void Update () {
        if (animate_bool)
        {
            AnimateCharacter();
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left * speed);
            animate_bool = true;

        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * speed);
            animate_bool = true;

        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector2.down * speed);
            animate_bool = true;
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector2.up * speed);
            animate_bool = true;

        }

    }

    /// <summary>
    /// AnimateCharacter method, Determines animations.
    /// </summary>
    private void AnimateCharacter()
    {
        ResetAnimations();
        if (moveLeft)
        {
            anim.SetBool("moveLeft", true);
            sprite_render.sprite = sprite_list[3];
        }
        if (moveRight)
        {
            anim.SetBool("moveRight", true);
            sprite_render.sprite = sprite_list[1];
        }
        if (moveDown)
        {
            anim.SetBool("moveDown", true);
            sprite_render.sprite = sprite_list[0];
        }
        if (moveUp)
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
}
