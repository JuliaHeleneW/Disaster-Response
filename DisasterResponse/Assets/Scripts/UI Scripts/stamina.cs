using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stamina : fillBar
{

    private int staminaAmt = 50;
    private int maxStaminaAmt = 50;
    private bool changeStamina;

    //[SerializeField]
    //private Text staminaText;

    // Use this for initialization

    void Start()
    {
        changeStamina = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (changeStamina)
        {
            setFillBar(staminaAmt, maxStaminaAmt);
            changeStamina = false;
        }
    }

    public void useStamina(int amt)
    {
        staminaAmt = staminaAmt - amt;
        if(staminaAmt <= 0)
        {
            //Todo: Call method to make the player rest, which will
            //      make them unable to perform actions for a short time
        }
        changeStamina = true;
    }

    public void recoverStamina(int recoveredAmt)
    {
        if(staminaAmt == maxStaminaAmt)
        {
            Debug.Log("Stamina is full");
        }
        else if(staminaAmt + recoveredAmt > maxStaminaAmt)
        {
            staminaAmt = maxStaminaAmt;
            changeStamina = true;
        }
        else
        {
            staminaAmt = staminaAmt + recoveredAmt;
            changeStamina = true;
        }
    }
}
