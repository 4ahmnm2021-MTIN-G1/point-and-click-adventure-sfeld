﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    public InteractableObject activeUI;
    public canvasEvents canvasEvent;
    public GameObject useWithButtonUI;
    public Text dialogeDisplay;
    public GameObject[] itemSlots;
    int itemsInInvent;
    List<InteractableObject> itemTypesinInvent;
    public int margin;

    int currentSlot;
    public InteractableObject currentlyUsed;
    public static UIManager uIManager;
    public bool isCanvas = false;


    public void displayDialouge(int dialogeType)
    {
      if (!isCanvas)
        activeUI.TriggerDialogue(dialogeType);
      else
        canvasEvent.TriggerDialogue(dialogeType);
    }

    private void Start()
    {
        itemTypesinInvent = new List<InteractableObject>();
        uIManager = this;
    }

    public void Exit()
    {
        dialogeDisplay.text = "";
    }

    public void UseInventItem(int slot)
    {
        if (itemsInInvent > slot)
        {
            useWithButtonUI.SetActive(true);
            useWithButtonUI.transform.position = itemSlots[slot].transform.position;
            currentSlot = slot;
        }
    }

    public void UseItemWith()
    {
        currentlyUsed = itemTypesinInvent[currentSlot];
        itemSlots[currentSlot].GetComponent<Outline>().enabled = true; //Ah yes, v i s u a l    q u e u e s
    }
    public void StopUsing()
    {
        currentlyUsed = null;
        itemSlots[currentSlot].GetComponent<Outline>().enabled = false;

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
                itemTypesinInvent.Add(activeUI);
            }
            else if (itemsInInvent == itemSlots.Length)
                dialogeDisplay.text = "My Pockets are full";
        }

        else if (activeUI.collectableObjects.Length > 0)
        {
            if (itemsInInvent + activeUI.collectableObjects.Length < itemSlots.Length) // this whole if-statement situiation is kinda shady but it works for now
            {
                foreach (InteractableObject collectable in activeUI.collectableObjects)
                {
                    itemSlots[itemsInInvent].GetComponent<Image>().sprite = collectable.image.sprite;
                    collectable.image.sprite = null;
                    collectable.gameObject.SetActive(false);
                    itemsInInvent++;
                    itemTypesinInvent.Add(collectable.GetComponent<InteractableObject>());
                }
               
            }
            else if (itemsInInvent + activeUI.collectableObjects.Length >= itemSlots.Length)
                dialogeDisplay.text = "My Pockets are full";
        }
    }
}
