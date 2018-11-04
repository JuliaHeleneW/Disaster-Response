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
        Debug.Log("barRect: " + barRect);
        //if (healthText == null)
        //{
        //    Debug.LogError("STATUS INDICATOR: No health bar referenced.");
        //}
    }

    public void setBarRect(RectTransform other)
    {
        barRect = other;
    }

    public void setFillBar(float current, float max)
    {
        float value = current / max;

        barRect.localScale = (new Vector3(value, 1f, 1f));
        //healthText.text = "Health: " + currHealth + "/" + maxHealth;
    }

}
