using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float boundLR = 11; //-left, +right
    private float boundTB = 11; //-bottom, +top

    private countdownTimer ctscript;


    private bool isDestroyed = false; // Flag to prevent multiple destroy calls

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyAfterTime(15.0f)); // Destroy after 15 seconds
        ctscript = GameObject.Find("TimerText").GetComponent<countdownTimer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDestroyed)
        {
            // Debug.Log("X position: " + transform.position.x);
            if (transform.position.x < -11)
            {// Left bound
                Destroy(gameObject);
                isDestroyed = true;
            }
            else if (transform.position.x > boundLR + 0.6)
            {// Right bound
                Destroy(gameObject);
                isDestroyed = true;
                //Debug.Log("DESTROYED! RIGHT");
            }
            else if (transform.position.y > boundTB)
            {// Top bound
                Destroy(gameObject);
                isDestroyed = true;
            }
            else if (transform.position.y < -boundTB)
            {// Bottom bound
                Destroy(gameObject);
                isDestroyed = true;
            }
        }
        if (ctscript.currentTime <= 6) {
            Debug.Log("Goodbye bug!");
            StartCoroutine(DestroyAfterTime(2.0f)); }
    }

    IEnumerator DestroyAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
        isDestroyed = true;
    }
}
