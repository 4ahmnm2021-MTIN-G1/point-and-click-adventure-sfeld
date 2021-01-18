using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class followCursor : MonoBehaviour
{

    [SerializeField] GameObject followObject;
    Text displayText; 

    private void Start()
    {
        displayText = followObject.GetComponent<Text>();
        followObject.SetActive(false); 
    }

    //would it be smarter to only move the text when my cursor hovers over a collider?
    //probably 
    //do I have to to think about that 
    //no :)
    private void Update()
    {
       Vector2 mousePos = Input.mousePosition;
       Vector2  worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        followObject.transform.position = worldPos;
    }

    public void displayObjectName (string name)
    {
        followObject.SetActive(true);
        displayText.text = name; 
    }
}
