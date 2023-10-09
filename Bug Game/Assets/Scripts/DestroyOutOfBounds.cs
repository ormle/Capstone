using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float boundLR = 1750; //-left, +right
    private float boundTB = 1075; //-bottom, +top

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -boundLR)
        {//Left bound
            Destroy(gameObject);
        }
        else if (transform.position.x > boundLR)
        {//Right bound
            Destroy(gameObject);
            Debug.Log("DESTROYED!");
        }
        else if (transform.position.y > boundTB)
        {//Top bound
            Destroy(gameObject);
        }
        else if (transform.position.y < -boundTB)
        {//Bottom bound
            Destroy(gameObject);
        }
        
    }
}
