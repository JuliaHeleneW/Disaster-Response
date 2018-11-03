using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fillBar : MonoBehaviour
{

    [SerializeField]
    private RectTransform barRect;

    void Start()
    {
        if (barRect == null)
        {
            Debug.LogError("STATUS INDICATOR: No health bar referenced.");
        }
        //if (healthText == null)
        //{
        //    Debug.LogError("STATUS INDICATOR: No health bar referenced.");
        //}
    }

    public void setFillBar(int current, int max)
    {
        float value = (float)current / max;

        barRect.localScale = new Vector3(value, 1f, 1f);
        //healthText.text = "Health: " + currHealth + "/" + maxHealth;
    }

}
