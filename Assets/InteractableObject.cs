using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InteractableObject : MonoBehaviour
{
   public GameObject commandMenu;
    public Collider2D Letter;
    public UIManager uIManager;
    public string inspectText;
    public SpriteRenderer image;
    
    public void Start()
    {
        image = gameObject.GetComponent<SpriteRenderer>();
        commandMenu.SetActive(false);
    }

 

    

    public void OnMouseDown()
    {
        commandMenu.SetActive(true);
        commandMenu.transform.position = gameObject.transform.position;

        uIManager.activeUI = this;
       
        
    }
}
