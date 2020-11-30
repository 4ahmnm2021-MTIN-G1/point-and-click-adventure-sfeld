using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wizzard : MonoBehaviour
{
    public string name;
    public int age;
    public float height;
    public bool isAlive;
    public Transform transform;

    public Rigidbody rigidbody;
    public Text text;
    public GameObject textObject;
    // Start is called before the first frame update
    void Start()
    {
        name = "vico";
        age = 11;
        height = 1.44f;
        isAlive = false;

        rigidbody = GetComponent<Rigidbody>();
        rigidbody.mass = 50;
        rigidbody.useGravity = false;

        text = textObject.GetComponent<Text>();
        text.text = "Roses are red, and the stars are shining, look at that, my mental health is rapidly declining :)";
        text.fontSize = 23;

    }

   
}
