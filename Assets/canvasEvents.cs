using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class canvasEvents : MonoBehaviour
{
    //I'm slowly realising that giving every asset a scriptable object would have been so much simpler
    // :/ too bad! 

    public DesiredObject desiredObject;
    public int objectIndex;
    public int caseInt;

    public GameObject key;
    public GameObject commandMenu;
    public UIManager uIManager;
    public GameProgress gameProgress;
    public followCursor objectNameDisp;
    public SpriteRenderer image;

    public InteractableObject[] collectableObjects;
    public bool isInteractable = true;
    public bool checkOnUse; //I coulnd't think of anythink smarter so here come all the bools and manual labor for me :)
    public bool conditionNeeded;
    public int conditionIndex;


    public bool influencesCondition;
    public int influenceIndex;

    public Dialogue inspectDia;
    public Dialogue useDia;

    public Dialogue collectDia;
    public Dialogue rejectDia;

    public Dialogue[] storyDia;

    int margin;
    [SerializeField]
    int diaCount = 0;
    public void TriggerDialogue(int dialogeType)
    {
        switch (dialogeType)
        {
            case 1:
                DialogueManager.instance.StartDialogue(inspectDia);
                if (influenceIndex ==3)
                {
                    gameProgress.conditions[influenceIndex].isTrue = true;
                    image.enabled = false;
                    key.SetActive(true);
                    conditionIndex = 3;
                }
                break;
            
            case 2:

                UseWithCheck();
                if (conditionNeeded)
                    ConditionCheck();
                else
                    DialogueManager.instance.StartDialogue(useDia);

                break;

            case 3:
                DialogueManager.instance.StartDialogue(collectDia);
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

        margin = uIManager.margin;

        rejectDia.sentences[0] = "This does not work";
    }


    public void OnMouseDown()
    {
        if (isInteractable)
        {
            uIManager.isCanvas = true;
            commandMenu.SetActive(true);
            commandMenu.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -7);

            uIManager.canvasEvent = this;
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
        if (gameProgress.conditions[conditionIndex].isTrue)
        {
            desiredObject.executeComand(caseInt, image);
            DialogueManager.instance.StartDialogue(useDia);
            useDia = storyDia[diaCount];
            caseInt += 2;
            conditionIndex+=2;
            if (influencesCondition)
            {
                gameProgress.conditions[influenceIndex].isTrue = true;
            }
            if (gameProgress.conditions[2].isTrue)
            {
                influenceIndex = 3;
                inspectDia = storyDia[2];
              
            }
            if (caseInt == 3)
            {   
                inspectDia = storyDia[1];
                

            }

        }
        else
            DialogueManager.instance.StartDialogue(rejectDia);

          
    }


    public void UseWithCheck()
    {
        if (uIManager.currentlyUsed != null)
        {
            Debug.Log(uIManager.currentlyUsed.gameObject + "is currently loaded");
            if (uIManager.currentlyUsed.objectIndex == desiredObject.objectIndex)
            {
                Debug.Log("match Found" + uIManager.currentlyUsed.gameObject);
                desiredObject.executeComand(caseInt, image);
               
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
