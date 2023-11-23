using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Descriptions : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjust the speed as needed
    private bool movingUp = false;
    private bool movingDown = false;

    void Update()
    {
        // Check for button click to move the object up
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            movingUp = true;
            movingDown = false;
        }

        // Check for button click to move the object down
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            movingUp = false;
            movingDown = true;
        }

        // Move the object based on the current state
        if (movingUp)
        {
            MoveUp();
        }
        else if (movingDown)
        {
            MoveDown();
        }
    }

    void MoveUp()
    {
        // Move the object upward along the Y-axis
        
        // if (transform < -450) { // if transform is less than max height
        
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        //}
    }
    

    void MoveDown()
    {
        // Move the object downward along the Y-axis
        transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
    }
}
