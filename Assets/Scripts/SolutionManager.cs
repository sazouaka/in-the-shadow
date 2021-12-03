using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolutionManager : MonoBehaviour
{
    public RotationAndTranslation object1;
    public RotationAndTranslation object2;
    
    public float totalProgress;
    public RectTransform scaleImage;
    public float difficulty = 0.975f;
    
    public NextLevel levelUnlocked;
    public GameObject passedPanel;
    public GameObject pauseCanva;

    private void Start()
    {
        globalVar.isGamePaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        totalProgress = (object1.solutionProgress + object2.solutionProgress) / 2;
        scaleImage.transform.localScale = new Vector3(1, totalProgress, 1);
        
        // we compare our value to a game difficulty or a target value that means you have the correct shape
        if (totalProgress >= difficulty)
        {
            passedPanel.SetActive(true);
            globalVar.isGamePaused = true;
            pauseCanva.SetActive(false);
            levelUnlocked.ToNextLevel();
        }
    }
}
