using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    private static BackgroundMusic musicAudio;

    private void Awake()
    {
        if (musicAudio == null)
        {
            //PlayAudio this music
            musicAudio = this;
            
            // to prevent stoping music when we mive to other scenes
            DontDestroyOnLoad(transform.gameObject);
        }

        else
        {
            // if the music audio is on (!= null) then we destroy it when we click on music off
            Destroy(gameObject);
        }
    }
}
