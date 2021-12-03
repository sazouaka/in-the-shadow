using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class LevelManager : MonoBehaviour
{
    public int _levelUnlocked;

    public Button[] buttons;
    
    
    void Start()
    {
        // we store the key of the unlocked level at start on a file named PlayerPrefs
        if (_levelUnlocked != 0)
        {
            _levelUnlocked = PlayerPrefs.GetInt("_levelUnlocked", 1);
        }
        else
        {
            globalVar.isTestMode = true;
        }
        

        // make all the levels non interactable at first
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
            buttons[i].animator.enabled = false;
        }
        
        // make the unlocked levels interactable
        for (int i = 0; i < _levelUnlocked; i++)
        {
            buttons[i].interactable = true;
            if (i > 0)
            {
                buttons[i - 1].animator.enabled = false;
                buttons[i].animator.enabled = true;
                
            }
            if (i == 5)
            {
                buttons[i].animator.enabled = false;
            }
        }
    }

    public void SceneLoader(int Index)
    {
        // for each level button load the linked scene
        SceneManager.LoadScene(Index);
    }

    public void ResetLevel()
    {
        PlayerPrefs.SetInt("_levelUnlocked", 1);
        SceneManager.LoadScene(7);
    }
}
