using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;


public class SoundManager : MonoBehaviour
{
    public Image soundOnIcon;
    public Image soundOffIcon;
    private bool muted = false;

    void Start()
    {
        // if we don't have a saved state of music from previous game then
        // by default muted is false which means music is on
        if (!PlayerPrefs.HasKey("muted"))
        {
            PlayerPrefs.SetInt("muted", 0);
            Load();
        }

        else
        {
            Load();
        }
        
        UpdateButtonIcon();
        AudioListener.pause = muted;
    }

    public void OnButtonPress()
    {
        // if we click on sound button and music is On this function would disable sound from all the game
        if (muted == false)
        {
            muted = true;
            AudioListener.pause = true;
        }

        else
        {
            muted = false;
            AudioListener.pause = false;
        }
        
        Save();
        UpdateButtonIcon();
    }

    private void UpdateButtonIcon()
    {
        if (muted == false)
        {
            soundOnIcon.enabled = true;
            soundOffIcon.enabled = false;
        }
        else
        {
            soundOnIcon.enabled = false;
            soundOffIcon.enabled = true;
        }
    }
    
    private void Load()
    {
        // we get the state of muted depending on its value in playerprefs. if its 1 then it will have true as state
        muted = PlayerPrefs.GetInt("muted") == 1;
    }

    private void Save()
    {
        // playerpref doesn't save bool variables so we convert it to integer. true is 1 and false is 0
        PlayerPrefs.SetInt("muted", muted ? 1 : 0);
    }
}
