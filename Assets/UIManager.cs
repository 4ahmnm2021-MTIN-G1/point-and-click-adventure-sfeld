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

    public void displayDialouge(int dialogeType)
    {
      
        activeUI.TriggerDialogue(dialogeType);
    }
    
    public void Exit()
    {
        dialogeDisplay.text = "";
    }

    public void CollectItem()
    {
        if (activeUI.isCollectible)
        {
            if (itemsInInvent < itemSlots.Length)
            {
                itemSlots[itemsInInvent].GetComponent<Image>().sprite = activeUI.image.sprite;
                activeUI.image.sprite = null;
                activeUI.gameObject.SetActive(false);
                itemsInInvent++;
            }
            else if (itemsInInvent == itemSlots.Length)
                dialogeDisplay.text = "My Pockets are full";
        }

        else if (activeUI.collectableObjects.Length > 0)
        {
            if (itemsInInvent + activeUI.collectableObjects.Length < itemSlots.Length)
            {
                foreach (InteractableObject collectable in activeUI.collectableObjects)
                {
                    itemSlots[itemsInInvent].GetComponent<Image>().sprite = collectable.image.sprite;
                    collectable.image.sprite = null;
                    collectable.gameObject.SetActive(false);
                    itemsInInvent++;
                }
               
            }
            else if (itemsInInvent + activeUI.collectableObjects.Length >= itemSlots.Length)
                dialogeDisplay.text = "My Pockets are full";
        }
    }
}
