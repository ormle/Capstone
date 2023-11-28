using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TouchScript.Gestures;
using System;

public class Descriptions : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjust the speed as needed
    private bool movingUp = false;
    private bool movingDown = false;
    private bool isTapped = false;

    void Start()
    {
        TapGesture tapGesture = this.GetComponent<TapGesture>();
        tapGesture.Tapped += TapGesture_Tapped;
    }

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
            moveSpeed = 2;
            MoveDown();
        }
    }
    
    void TapGesture_Tapped(object sender, EventArgs e)
    {
        Debug.Log("Tapped! Initiating MoveDown()");
        movingUp = false;
        movingDown = true;
    }
    

    void MoveUp()
    {
        // Move the object upward along the Y-axis
        float newY = transform.position.y + (Vector3.up.y * moveSpeed * Time.deltaTime);

        // Set the maximum height (adjust this value as needed)
        float maxHeight = 0f;

        // Gradually decrease the value of newY
        newY = Mathf.Lerp(transform.position.y, maxHeight, Time.deltaTime * moveSpeed);

        // Apply the new position
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);

        // Check if the object has reached the maximum height
        if (newY >= maxHeight)
        {
            // Stop moving up
            movingUp = false;
            moveSpeed = 0;
        }
    }

    public void MoveDown()
    {   
        //Debug.Log("moving down! Initiating MoveDown()");
        // Move the object downward along the Y-axis
        float newY = transform.position.y + (Vector3.down.y * moveSpeed * Time.deltaTime);

        // Set the minimum height (adjust this value as needed)
        float minHeight = -10f;

        // Gradually increase the value of newY
        newY = Mathf.Lerp(transform.position.y, minHeight, Time.deltaTime * moveSpeed);

        // Apply the new position
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);

        // Check if the object has reached the minimum height
        if (newY <= minHeight)
        {
            // Stop moving down
            movingDown = false;
            moveSpeed = 0;
        }
    }

}
