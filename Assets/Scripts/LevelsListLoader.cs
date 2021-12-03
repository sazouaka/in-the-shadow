using UnityEngine;
using UnityEngine.UI;

public class LevelsListLoader : MonoBehaviour
{
    private int _currentLevelsList;
    [SerializeField] private Button _nextButt;
    [SerializeField] private Button _prevButt;

    private void Awake()
    {
        LoadLevels(0);
    }
   
    private void LoadLevels(int index)
    {
        // disable prev butt when we are on the first 3 levels
        if (index != 0)
        {
            _prevButt.interactable = true;
        }
        else
        {
            _prevButt.interactable = false;
        }


        // disable next butt when we are on the last 3 levels
        if (index != transform.childCount - 1)
        {
            _nextButt.interactable = true;
         
        }
        else
        {
            _nextButt.interactable = false;
         
        }
      
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(i == index);
        }
    }

    public void ChangeLevelsList(int change)
    {
        _currentLevelsList += change;
        LoadLevels(_currentLevelsList);
    }
}
