using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCamera : MonoBehaviour
{
    //How do I do this?

    public GameObject mainCam;
    private float posRight = 3.65f;
    private float posLeft = -3.65f;
    public float screenWidth = 1280; 


    public void OnMouseDown()
    {
        float range = Mathf.Abs(posLeft) + posRight;

        print(Input.mousePosition); // in realtion to screen 
        float relation = Input.mousePosition.x / screenWidth;
        print (relation); 
        if( relation > 0.7f)
        {
            mainCam.gameObject.transform.position = new Vector3(posRight, mainCam.gameObject.transform.position.y, mainCam.gameObject.transform.position.z);
        }
        else if (relation < 0.3f)
        {
            mainCam.gameObject.transform.position = new Vector3(posLeft, mainCam.gameObject.transform.position.y, mainCam.gameObject.transform.position.z);
        }

       
    }
}
