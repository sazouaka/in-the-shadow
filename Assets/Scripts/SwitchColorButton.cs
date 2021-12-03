using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental;
using UnityEngine.UI;
using UnityEngine;

public class SwitchColorButton : MonoBehaviour
{
    [SerializeField] int count = 0;
    [SerializeField] Color[] colorArray;
    
    public void changeColor()
    {
        if (count < colorArray.Length)
        {
            globalVar.lightColor = new Color(colorArray[count].r, colorArray[count].g, colorArray[count].b);
            gameObject.GetComponent<Image>().color = globalVar.lightColor;
            if (count == colorArray.Length - 1)
            {
                count = -1;
            }
            count++;
        }
    }
}
