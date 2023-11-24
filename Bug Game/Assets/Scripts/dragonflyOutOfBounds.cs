using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragonflyOutOfBounds : MonoBehaviour
{
    private float boundLR = 11; //-left, +right
    private float boundTB = 11; //-bottom, +top

    private bool isDestroyed = false; // Flag to prevent multiple destroy calls

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyAfterTime(30.0f)); // Destroy after 30 seconds
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDestroyed)
        {
            // Debug.Log("X position: " + transform.position.x);
            if (transform.position.x < - 20)
            {// Left bound
                Destroy(gameObject);
                isDestroyed = true;
                Debug.Log("DESTROYED! left");
            }
            else if (transform.position.x > boundLR + 20)
            {// Right bound
                Destroy(gameObject);
                isDestroyed = true;
                Debug.Log("DESTROYED! RIGHT");
            }
            else if (transform.position.y > boundTB + 20)
            {// Top bound
                Destroy(gameObject);
                isDestroyed = true;
                Debug.Log("DESTROYED! top");
            }
            else if (transform.position.y < -boundTB - 20)
            {// Bottom bound
                Destroy(gameObject);
                isDestroyed = true;
                Debug.Log("DESTROYED! bottom");
            }
        }
    }

    IEnumerator DestroyAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
        isDestroyed = true;
    }
}
