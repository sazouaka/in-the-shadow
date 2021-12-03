using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToPlay : MonoBehaviour
{
    public GameObject HowToPlayPannel;
    public bool HowToIsOpen = false;

    public void EnableHowToPlay()
    {
        if (HowToIsOpen)
        {
            HowToPlayPannel.SetActive(false);
            HowToIsOpen = false;
        }
        else
        {
            HowToPlayPannel.SetActive(true);
            HowToIsOpen = true;
        }
    }
}
