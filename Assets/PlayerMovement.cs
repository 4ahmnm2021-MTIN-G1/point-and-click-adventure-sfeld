using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public GameObject player;
    public Vector3 mousePos;
    public Vector3 worldPos;
    Vector3 playerPos;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerPos = player.transform.position;
       
    }

    // Update is called once per frame
    public void MovePlayer()
    {
       
        mousePos = Input.mousePosition;
        worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        playerPos= new Vector3(worldPos.x, worldPos.y, gameObject.transform.position.z);
       
    }

    private void Update()
    {
     
        player.transform.position = Vector3.MoveTowards(player.transform.position, playerPos, speed);
    }

    
}
