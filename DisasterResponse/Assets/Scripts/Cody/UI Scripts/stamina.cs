using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stamina : fillBar
{

    private int staminaAmt;
    private int maxStaminaAmt;
    private bool changeStamina;

    public stamina(int maxStamina)
    {
        if (maxStamina <= 0)
        {
            Debug.LogWarning("Negative input, setting stamina to 100");
            maxStaminaAmt = 100;
        }
        else
        {
            maxStaminaAmt = maxStamina;
        }
        staminaAmt = maxStaminaAmt;
        this.setBarRect(GameObject.Find("yellowStaminaBar").GetComponent<RectTransform>());
    }

    //[SerializeField]
    //private Text staminaText;

    // Use this for initialization

    void Start()
    {
        changeStamina = false;
    }

    // Update is called once per frame
    public void checkStamina()
    {
        if (changeStamina)
        {
            if(staminaAmt <= 0)
            {
                staminaAmt = 0;
            }
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
        if(staminaAmt + recoveredAmt > maxStaminaAmt)
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
