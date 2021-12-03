using UnityEngine;
using UnityEngine.SceneManagement;

public class RotationAndTranslation : MonoBehaviour
{
    private float rotationSpeed = 1000f;
    private float moveSpeed = 100f;
    private float object_Y;
    private float object_X;
    public float solutionProgress;
    public Vector3 objectsolutionPos;
    public Quaternion objectsolutionRot;
    
    public float cmpval;
    public float rotValue;
    
    public GameObject passedPanel;
    
    public float posValue;
    public float distance;
    
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
        passedPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    void OnMouseDrag()
    {
        /* we use The follow to freez the game */
        if (globalVar.isGamePaused)
            return;
        
        object_X = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        object_Y = Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;


        
        /*if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            object_Y = 0;
        }*/
        
        if (SceneManager.GetActiveScene().buildIndex >= 3 && Input.GetKey(KeyCode.LeftControl))
        {
            Vector3 pos = (object_X / moveSpeed) * Vector3.left + (object_Y / moveSpeed) * Vector3.up;
            transform.position += pos;
        }
        else if (Input.GetKey(KeyCode.LeftAlt))
        {
            transform.rotation = Quaternion.AngleAxis(object_Y, Vector3.left) * transform.rotation;
        }
        else
        {
            transform.rotation = Quaternion.AngleAxis(-object_X, Vector3.up) * transform.rotation;
            transform.rotation = Quaternion.AngleAxis(object_Y, Vector3.back) * transform.rotation;
        }

        // Quaternion.identity is the rotation 0 
        cmpval = Quaternion.Angle(objectsolutionRot, transform.rotation);
        Vector3 solutionPosition = objectsolutionPos;
        distance = Vector3.Distance(solutionPosition, transform.position);
        
        // we substract 360 to make the position varies between 180 and -180
        if (cmpval > 180)
            cmpval = 360 - cmpval;
        
        rotValue = Mathf.InverseLerp(180, 0, cmpval);//rotation
        posValue = Mathf.InverseLerp(1, 0, distance);//position
        solutionProgress = (rotValue + posValue) / 2;
    }
}
