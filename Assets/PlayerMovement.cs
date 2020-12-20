using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    public Vector3 mousePos;
    public Vector3 worldPos;
    Vector3 playerPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Input.mousePosition;
        worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        gameObject.transform.position = new Vector3(worldPos.x, worldPos.y, gameObject.transform.position.z);
    }
}
