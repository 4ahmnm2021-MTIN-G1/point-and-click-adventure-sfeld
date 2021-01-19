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



    [SerializeField]  float minScale;
    [SerializeField] float maxScale;

    [Range(0, 1)]
    public float test;


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
        print(worldPos);
        playerPos= new Vector3(worldPos.x, worldPos.y, gameObject.transform.position.z);
       
    }

    private void Update()
    {
     
        player.transform.position = Vector3.MoveTowards(player.transform.position, playerPos, speed);
        AdjustPlayerScale(player.transform.position.y);
    }

    void AdjustPlayerScale(float yPos)
    {
        //M A T H
        //this converts the world ypos to a value between 0 (front edge) and 1 (back edge) so I can use it in a lerp 
        float postiveY = yPos + 2.4f;
        float ratio = postiveY / 2.9f;

        float scale = Mathf.Lerp(minScale, maxScale, ratio);
        player.transform.localScale = new Vector3(scale, scale, scale);


    }
}
