using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TurnOffMusic : MonoBehaviour
{
    public GameObject musicAudio;
    private bool musicOn = true;
    public Image musicOnIcon;
    public Image musicOffIcon;

    void Start()
    {
        // if we don't have a saved state of music from previous game then
        // by default musicOn is true which means music is on
        if (!PlayerPrefs.HasKey("musicOn"))
        {
            PlayerPrefs.SetInt("musicOn", 1);
            LoadMusic();
        }
        else
        {
            LoadMusic();
        }
        UpdateMusicButtonIcon();
        musicAudio.SetActive(musicOn);
    }
    
    public void stopMusic()
    {
        if (musicOn)
        {
            musicOn = false;
            musicAudio.SetActive(false);
        }
        else
        {
            musicOn = true;
            musicAudio.SetActive(true);
        }
        Savemusic();
        UpdateMusicButtonIcon();
    }
    
    private void UpdateMusicButtonIcon()
    {
        if (musicOn)
        {
            musicOnIcon.enabled = true;
            musicOffIcon.enabled = false;
        }
        else
        {
            musicOnIcon.enabled = false;
            musicOffIcon.enabled = true;
        }
    }
    
    private void LoadMusic()
    {
        // we get the state of muted depending on its value in playerprefs. if its 1 then it will have true as state
        musicOn = PlayerPrefs.GetInt("musicOn") == 1;
    }

    private void Savemusic()
    {
        // playerpref doesn't save bool variables so we convert it to integer. true is 1 and false is 0
        PlayerPrefs.SetInt("musicOn", musicOn ? 1 : 0);
    }
}
