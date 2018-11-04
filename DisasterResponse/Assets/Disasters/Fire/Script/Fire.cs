using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {
    private Animator anim;      // To hold the fire's animator
    private float fire_timer;   // To hold the timer for the fire
    private BoxCollider2D fireColl;
    private CircleCollider2D fireTrig;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();    // set anin to components animator
        anim.Play("small_fire");            // set start animation at small fire
        fire_timer = 0;                     // set timer to 0
	}
	
	// Update is called once per frame
	void Update () {
        FireLife();     // Determines life of fire
	}

    /// <summary>
    /// FireLife method: Determines life of fire
    /// </summary>
    private void FireLife()
    {
        fireColl = GetComponent<BoxCollider2D>();
        fireTrig = GetComponent<CircleCollider2D>();

        fire_timer++;       // increment fire timer

        // if fire timer is less than zero, destroy object
        if (fire_timer < 0)
        {
            Destroy(gameObject);
        }

        // Fire get's stronger the longer it lives
        if (fire_timer < 1800)
        {
            anim.Play("small_fire");
        }
        else if (fire_timer > 1800 && fire_timer < 3600)
        {
            anim.Play("medium_fire");
            fireColl.size = new Vector2(2.56f, 2.88f);
            fireTrig.radius = 3.5f;
        }
        else if (fire_timer > 3600)
        {
            anim.Play("large_fire");
            fireColl.size = new Vector2(3.2f, 3.54f);
            fireTrig.radius = 4;
        }
        //Debug.Log(fire_timer);

        fire_timer = (fire_timer > 4200) ? 4200 : fire_timer;   // fire_timer can't pass 70 seconds
    }
    
    /// <summary>
    /// ReduceFire method: Reduce the fire life span by, reduction
    /// </summary>
    /// <param name="reduction"></param>
    public void ReduceFire(float reduction)
    {
        fire_timer -= reduction;
    }

}
