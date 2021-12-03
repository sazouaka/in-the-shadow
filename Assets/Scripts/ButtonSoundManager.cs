using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSoundManager : MonoBehaviour
{
    public AudioSource buttonSound;

    public void HoverSound()
    {
        buttonSound.Play();
    }
}
