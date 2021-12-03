using UnityEngine;
using  Cinemachine;

public class UITransitionManager : MonoBehaviour
{
    // Reference to The first camera we need
    
    public CinemachineVirtualCamera MenuCam;
    public CinemachineVirtualCamera ModeCam;
    public CinemachineVirtualCamera SettingsCam;
    public CinemachineVirtualCamera ExitCam;
    
    public CinemachineVirtualCamera CurrentCam;
    
    public void Start()
    {
        CurrentCam.Priority++;
    }

    /* We decrease the priority camera of the current active camera then we assign the next camera
    as the current active one and we increase the priority of new camera */
    
    public void UpdateCam(CinemachineVirtualCamera target)
    {
        CurrentCam.Priority--;

        CurrentCam = target;
      
        CurrentCam.Priority++;
    }
    
    public void GoToMainMenuCam()
    {
        if (ModeCam.Priority > MenuCam.Priority)
        {
            ModeCam.Priority--;
            MenuCam.Priority++;
            CurrentCam = MenuCam;
        }
        else if (SettingsCam.Priority > MenuCam.Priority)
        {
            SettingsCam.Priority--;
            MenuCam.Priority++;
            CurrentCam = MenuCam;
        }
        else if (ExitCam.Priority > MenuCam.Priority)
        {
            ExitCam.Priority--;
            MenuCam.Priority++;
            CurrentCam = MenuCam;
        }
    }
}
