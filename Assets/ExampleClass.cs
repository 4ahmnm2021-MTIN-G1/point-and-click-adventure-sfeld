using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleClass : MonoBehaviour
{
    float massScale = 3;
    int orderInLayer = 2;
    bool islooping = true;
    string name = "this is a name";

    public GameObject referenceObject;
    HingeJoint joint;
    AudioSource music;
    SpriteRenderer sprite;

    private void Start()
    {
        // If i needed to refer to a component more than once i'd obvioulsy make a global variable for it and assign it with get component at the start
        // because writing a lot = bad. For this single use it works fine tho. 

        referenceObject.name = name;
        referenceObject.GetComponent<HingeJoint>().massScale = massScale;
        referenceObject.GetComponent<SpriteRenderer>().sortingOrder = orderInLayer;
        referenceObject.GetComponent<AudioSource>().loop = islooping; 
    }

}
