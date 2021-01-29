﻿
using UnityEngine;



    [CreateAssetMenu(fileName = "test", menuName = "Assets/Ítems")]
    public class DesiredObject : ScriptableObject, ISerializationCallbackReceiver
    {
        //oh boy I  think it's scriptable object time
        //this better work or I will cry 
        //is venting in the code comments a good idea?
        //probably not 

        public GameObject gameObject;
        public Sprite[] sprites;
        
        public int spriteNumber = 0;
        public int objectIndex;
        public int[] indexBacklog;

        public GameObject chara;
        public Dialogue dia1;

        [SerializeField]
        int counting;


        public void executeComand(int i, SpriteRenderer renderer) //this is dumb but it's 1am 
        {
            switch (i)
            {
                case (1):
                    renderer.sprite = sprites[spriteNumber];
                    objectIndex = indexBacklog[counting];
                    spriteNumber++;
                    counting++;
                    break;

                case (2):
                    chara = GameObject.FindGameObjectWithTag("Player");
                    GameObject.Instantiate(gameObject, chara.transform);
                    GameProgress.gameProgress.conditions[i].isTrue = true;
                    break;

                case (3):
                    if (GameProgress.gameProgress.conditions[1].isTrue && GameProgress.gameProgress.conditions[2].isTrue)
                    {
                        renderer.sprite = sprites[spriteNumber];
                        DialogueManager.instance.StartDialogue(dia1);
                        objectIndex = indexBacklog[counting];
                    spriteNumber++;
                    counting++;
                    break;
                    }
         
                    break;
            case (4):
                DialogueManager.instance.StartDialogue(dia1);
                renderer.sprite = sprites[0];
                break;

        }
        
        }

        public void OnAfterDeserialize()
        {
            spriteNumber = 0;
        counting = 0;
        }

        public void OnBeforeSerialize()
        {
            
        }
    }


    
