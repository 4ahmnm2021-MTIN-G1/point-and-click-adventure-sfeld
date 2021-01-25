using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

[CreateAssetMenu(fileName = "test", menuName ="Assets/Ítems")]
public class DesiredObject : ScriptableObject
{
    //oh boy I  think it's scriptable object time
    //this better work or I will cry 
    //is venting in the code comments a good idea?
    //probably not 

    public GameObject gameObject;
    public Sprite[] sprites;
    int spriteNumber;
    public int objectIndex;


public void switchSprite(SpriteRenderer renderer)
    {
        renderer.sprite = sprites[spriteNumber];
    }
    
}
