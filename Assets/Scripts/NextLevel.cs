using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    [SerializeField] int currentLevel;
    
    public void ToNextLevel()
    {
        int _maxLevels = 6;
    
        //currentLevel = SceneManager.GetActiveScene().buildIndex;
        currentLevel = SceneManager.GetActiveScene().buildIndex;

        if (currentLevel >= PlayerPrefs.GetInt("_levelUnlocked") && currentLevel + 1 <= _maxLevels && !globalVar.isTestMode)
        {
            // the current level + 1 is stored on a file
            PlayerPrefs.SetInt("_levelUnlocked", currentLevel + 1);
        }
    }
}
