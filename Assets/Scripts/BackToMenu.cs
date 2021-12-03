using UnityEngine;
using Cinemachine;

public class BackToMenu : MonoBehaviour
{
    // Reference to The first camera we need
    
    public CinemachineVirtualCamera MenuCam;
    public CinemachineVirtualCamera ModeCam;
    public CinemachineVirtualCamera SettingsCam;
    public CinemachineVirtualCamera ExitCam;
    
  public void Start()
  {
      //Debug.Log("happened");

  } 
    
    public void GoToMainMenuCam()
    {
        Debug.Log("happened");
        if (ModeCam.Priority > MenuCam.Priority)
        {
            ModeCam.Priority--;
            MenuCam.Priority++;
        }
        else if (SettingsCam.Priority > MenuCam.Priority)
        {
            SettingsCam.Priority--;
            MenuCam.Priority++;
        }
        else if (ExitCam.Priority > MenuCam.Priority)
        {
            ExitCam.Priority--;
            MenuCam.Priority++;
        }
        
    }
    
}
