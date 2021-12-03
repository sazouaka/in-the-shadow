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

/*
 * ******* solution for 13 *************
 * pos_vector3: 1.006, 3, -4.6
 * rot_quaternion: 359.9932, 359.3659, 359.8501
 *
 * ******* solution for 37 **************
 * pos_vector3: 0.5, 3, -4.6
 * rot_quaternion: 359.9821, 358.757, 359.7731
 */


/*
 * ******* solution for head *************
 * pos_vector3: 0.5205635, 3.361713, -4.3
 * rot_quaternion: 276.8294, 301.2431, 75.43774
 *
 * ******* solution for body **************
 * pos_vector3: 0.7812213, 2.665672, -4.3
 * rot_quaternion: 276.6199, 133.2115, 232.0279
 */

/*
 * ******* solution for 2 *************
 * rot_quaternion: 3.20985, 7.076204, 178.1716
 * pos_vector3: 0.6704075, 3.148136, -4
 *
 * ******* solution for 4 **************
 * rot_quaternion: 3.564365, 5.239114, 358.5368
 * pos_vector3: 1.325776, 3.077281, -4
 */

/*
 * ******* solution for glob_earth *************
 * pos_vector3: 0.5613996, 3, -4.8
 * rot_quaternion: 358.0873, 281.5536, 80.3734
 *
 * ******* solution for glob_base **************
 * pos_vector3: 0.5832446, 3.023451, -4.8
 * rot_quaternion: 275.9053, 39.32836, 326.7325
 */