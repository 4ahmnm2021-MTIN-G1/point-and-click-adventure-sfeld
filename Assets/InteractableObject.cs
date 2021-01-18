using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InteractableObject : MonoBehaviour
{
   public GameObject commandMenu;
    public UIManager uIManager;
    public followCursor objectNameDisp;
    public SpriteRenderer image;

    public InteractableObject[] collectableObjects;
    public bool isInteractable = true;
    public bool isCollectible = true;
  
    public Dialogue inspectDia;
    public Dialogue useDia;
    public Dialogue collectDia;

    public void TriggerDialogue(int dialogeType)
    {
        switch (dialogeType)
        {
            case 1:
                DialogueManager.instance.StartDialogue(inspectDia);
                break;
            case 2:
                DialogueManager.instance.StartDialogue(useDia);
                break;
            case 3:
                DialogueManager.instance.StartDialogue(collectDia);
                break;
        }

        
    }

     public void Start()
    {
        image = gameObject.GetComponent<SpriteRenderer>();
        commandMenu.SetActive(false);

        inspectDia.objectName = gameObject.name;
        useDia.objectName = gameObject.name;
        collectDia.objectName = gameObject.name;
        uIManager = GameObject.Find("UIManager").GetComponent<UIManager>();
    }


    public void OnMouseDown()
    {
        if (isInteractable)
        {
            commandMenu.SetActive(true);
            commandMenu.transform.position = gameObject.transform.position;

            uIManager.activeUI = this;
        }
    }
    public void OnMouseOver()
    {
        
    }
}
