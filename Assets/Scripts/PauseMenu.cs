using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool GameIsPause = false;

    public GameObject PauseMenuUI;

    private void Start()
    {
        PauseMenuUI.SetActive(false);
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPause)
            {
                Resume();
            }
        }
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        globalVar.isGamePaused = false;
        GameIsPause = false;
    }
    
    public void Pause()
    {
        PauseMenuUI.SetActive(true);
        globalVar.isGamePaused = true;
        GameIsPause = true;
    }

    /*public void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }*/
    
    public void ExitGame()
    {
        Application.Quit();
    }
    
}
