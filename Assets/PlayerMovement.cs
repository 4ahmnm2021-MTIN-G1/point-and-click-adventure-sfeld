using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    GameObject player;
    public Vector3 mousePos;
    public Vector3 worldPos;
    Vector3 playerPos;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    public void MovePlayer(GameObject player)
    {
       
        mousePos = Input.mousePosition;
        worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        player.transform.position = new Vector3(worldPos.x, worldPos.y, gameObject.transform.position.z);
    }

    private void OnMouseDown()
    {
        MovePlayer(player);
    }

}
