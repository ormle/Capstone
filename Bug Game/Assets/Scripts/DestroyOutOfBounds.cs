using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    /*
     * As of right now (Oct 5 as i write this)
     * Only applies to left and right bounds
     * ***Needs to be edited to include bugs that enter top+bottom bounds***
     */
    private float boundLR = 1800.0f; //-left, +right
    private float boundTB = 1200.0f; //-bottom, +top

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > boundLR || transform.position.x < -boundLR)
        {//Left-Right bound
            Destroy(gameObject);
        }
        else if (transform.position.y > boundTB || transform.position.y < -boundTB)
        {//Top-Bottom bound
            Destroy(gameObject);
        }
    }
}
