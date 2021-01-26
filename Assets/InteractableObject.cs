using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InteractableObject : MonoBehaviour
{
    //I'm slowly realising that giving every asset a scriptable object would have been so much simpler
    // :/ too bad! 

    public DesiredObject desiredObject;
    public int objectIndex;
    public int caseInt;

   public GameObject commandMenu;
    public UIManager uIManager;
    public GameProgress gameProgress; 
    public followCursor objectNameDisp;
    public SpriteRenderer image;
    public SpriteRenderer secondImage;
     

    public InteractableObject[] collectableObjects;
    public bool isInteractable = true;
    public bool isCollectible = true;
    public bool checkOnUse; //I coulnd't think of anythink smarter so here come all the bools and manual labor for me :)
    public bool conditionNeeded;
    public int conditionIndex;


    public bool influencesCondition;
    public int influenceIndex;
  
    public Dialogue inspectDia;
    public Dialogue useDia;
    
    public Dialogue collectDia;
    public Dialogue rejectDia;

    

    public void TriggerDialogue(int dialogeType)
    {
        switch (dialogeType)
        {
            case 1:
                DialogueManager.instance.StartDialogue(inspectDia);
                break;
            case 2:
                
                UseWithCheck();
                if(checkOnUse)
                ConditionCheck();
                else
                DialogueManager.instance.StartDialogue(useDia);

                break; 
               
            case 3:
                DialogueManager.instance.StartDialogue(collectDia);
                if (!checkOnUse)
                    ConditionCheck();
                break;
        }

        
    }

     public void Start()
    {
        uIManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        objectNameDisp = GameObject.Find("UIManager").GetComponent<followCursor>();
        gameProgress = GameObject.Find("UIManager").GetComponent<GameProgress>();

        image = gameObject.GetComponent<SpriteRenderer>();
        commandMenu.SetActive(false);

        inspectDia.objectName = gameObject.name;
        useDia.objectName = gameObject.name;
        collectDia.objectName = gameObject.name;

       
        rejectDia.sentences[0] = "This does not work";
    }


    public void OnMouseDown()
    {
        if (isInteractable)
        {
            commandMenu.SetActive(true);
            commandMenu.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -7);

            uIManager.activeUI = this;
        }
    }
    public void OnMouseOver()
    {
        objectNameDisp.displayObjectName(gameObject.name);
    }
    private void OnMouseExit()
    {
        objectNameDisp.setInactive();
    }

    void ConditionCheck()
    {
       
        if (conditionNeeded == false)
        {
            if(checkOnUse)
            DialogueManager.instance.StartDialogue(useDia);
            else
                DialogueManager.instance.StartDialogue(collectDia);
            if (influencesCondition)
            {
                gameProgress.conditions[influenceIndex].isTrue = true;
                
            }
        }
        else
        {
            if (gameProgress.conditions[conditionIndex].isTrue)
            {
                
                //do something
                DialogueManager.instance.StartDialogue(useDia);
                useDia.sentences[0].Remove(0);
                desiredObject.executeComand(caseInt, image);
                caseInt+= 2;

            }
            else
                DialogueManager.instance.StartDialogue(rejectDia);

            if (influencesCondition)
            {
                gameProgress.conditions[influenceIndex].isTrue = true;
            }
        }
    }


    public void UseWithCheck()
        {
            if (uIManager.currentlyUsed != null)
            {
            Debug.Log(uIManager.currentlyUsed.gameObject + "is currently loaded");
            if (uIManager.currentlyUsed.objectIndex == desiredObject.objectIndex)
            {
                Debug.Log("match Found" + uIManager.currentlyUsed.gameObject);
                desiredObject.executeComand( caseInt, image);
            }
            else
                print("does not match");
            DialogueManager.instance.StartDialogue(rejectDia);
                    return;
            }
            else
                return;
        }
        

}
