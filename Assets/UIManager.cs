using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    public InteractableObject activeUI;
    public Text dialogeDisplay;
    public GameObject[] itemSlots;
    int itemsInInvent;

    public void displayDialouge()
    {
        dialogeDisplay.text = activeUI.inspectText;
        activeUI.TriggerDialogue();
    }
    
    public void Exit()
    {
        dialogeDisplay.text = "";
    }

    public void CollectItem()
    {
        if (itemsInInvent < itemSlots.Length)
        {
            itemSlots[itemsInInvent].GetComponent<Image>().sprite =  activeUI.image.sprite  ;
            activeUI.image.sprite = null;
            activeUI.gameObject.SetActive(false);
            itemsInInvent++;
        }
        else if (itemsInInvent == itemSlots.Length)
            dialogeDisplay.text = "My Pockets are full";
    }
 
}
