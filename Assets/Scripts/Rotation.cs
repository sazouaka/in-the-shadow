using UnityEngine;
using UnityEngine.SceneManagement;

public class Rotation : MonoBehaviour
{
    private float rotationSpeed = 1000f;
    private float moveSpeed = 100f;
    private float object_Y;
    private float object_X;
    
    public RectTransform scaleImage;
    public float difficulty = 0.99f;
    private float cmpval;
    public float rotValue;
    
    public NextLevel levelUnlocked;
    public GameObject passedPanel;
    public GameObject pauseCanva;
    
    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            transform.Rotate(0, -103f, 0);
        }
        else if (SceneManager.GetActiveScene().buildIndex >= 2)
        {
            transform.Rotate(0, -100f, 100f);
        }
        if (globalVar.isGamePaused)
            globalVar.isGamePaused = false;
        passedPanel.SetActive(false);
    }

    void OnMouseDrag()
    {
        /* we use The follow to freez the game */
        if (globalVar.isGamePaused)
            return;
        
        object_X = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        object_Y = Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;


        
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            object_Y = 0;
        }
        if (Input.GetKey(KeyCode.LeftAlt))
        {
            transform.rotation = Quaternion.AngleAxis(object_Y, Vector3.left) * transform.rotation;
        }
        else
        {
            transform.rotation = Quaternion.AngleAxis(-object_X, Vector3.up) * transform.rotation;
            transform.rotation = Quaternion.AngleAxis(object_Y, Vector3.back) * transform.rotation;
        }
        
        /*if (SceneManager.GetActiveScene().buildIndex == 3 && Input.GetKey(KeyCode.LeftControl))
        {
            Vector3 pos = (object_X / moveSpeed) * Vector3.left + (object_Y / moveSpeed) * Vector3.up;
            transform.position += pos;
        }*/
            

        // Quaternion.identity is the rotation 0
        cmpval = Quaternion.Angle(Quaternion.identity, transform.rotation);
        
        // we substract 360 to make the position varies between 180 and -180
        if (cmpval > 180)
            cmpval = 360 - cmpval;
        
        rotValue = Mathf.InverseLerp(180, 0, cmpval);//rotation
        
        scaleImage.transform.localScale = new Vector3(1, rotValue, 1);

        // we compare our value to a game difficulty or a target value that means you have the correct shape
        if (rotValue >= difficulty)
        {
            passedPanel.SetActive(true);
            globalVar.isGamePaused = true;
            pauseCanva.SetActive(false);
            levelUnlocked.ToNextLevel();
        }
    }

}

