using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void LoadMainMenu()
    {
        if (globalVar.isTestMode)
            globalVar.isTestMode = false;
        SceneManager.LoadScene(0);
    }
    
    public void TestNormalMode()
    {
        if (globalVar.isTestMode)
        {
            SceneManager.LoadScene(8);
        }
        else
        {
            SceneManager.LoadScene(7);
        }
    }

    public void LoadSceneIndex(int index)
    {
        if (index == 8)
            globalVar.isTestMode = true;
        else
            globalVar.isTestMode = false;
        SceneManager.LoadScene(index);
    }
    
    public void ExitGame()
    {
        Application.Quit();
    }
}
