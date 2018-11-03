using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class health : fillBar {

    private int healthAmt = 50;
    private int maxHealthAmt = 50;
    private bool changeHealth;

    //[SerializeField]
    //private Text healthText;

    // Use this for initialization


    void Start()
    {
        changeHealth = false;
        
        //Todo: Implement getPlayerHealth, both healthAmt and changeHealth will use this.
        //healthAmt = ;
        //maxHealthAmt = healthAmt;
    }


    // Update is called once per frame
    void Update () {
        if (changeHealth){
            setFillBar(healthAmt, maxHealthAmt);
            changeHealth = false;
        }
	}

    //We decrease the healthAmt, calling gameOver if we reach 0 or less health.
    //Then set the dirtyFlag for updating the healthBar
    public void takeDamage(int damage)
    {
        healthAmt = healthAmt - damage;
        if(healthAmt <= 0)
        {
            //Todo: Call gameOver method here
        }
        else
        {
            changeHealth = true;
        }
    }

    //We change the o
    public void recoverHealth(int recoveredAmt)
    {
        if(healthAmt == maxHealthAmt)
        {
            Debug.Log("Health is full");
        }
        if (healthAmt + recoveredAmt > maxHealthAmt)
        {
            healthAmt = maxHealthAmt;
            changeHealth = true;
        }
        else
        {
            healthAmt = healthAmt + recoveredAmt;
            changeHealth = true;
        }
    }
}
