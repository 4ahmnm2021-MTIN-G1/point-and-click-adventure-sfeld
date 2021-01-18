using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveArea : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public SpriteRenderer spriteRenderer;
    public int orderInLayer;

    public void OnMouseDown()
    {
        playerMovement.MovePlayer();
        spriteRenderer.sortingOrder = orderInLayer;
    }
}
