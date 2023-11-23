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
            moveSpeed = 2;
            MoveDown();
        }
    }

    void MoveUp()
    {
        // Move the object upward along the Y-axis
        float newY = transform.GetComponent<RectTransform>().anchoredPosition.y + (Vector3.up.y * moveSpeed * Time.deltaTime);
    
        // Set the maximum height (adjust this value as needed)
        float maxHeight = -450f;
    
        // Check if the new position exceeds the maximum height
        if (newY < maxHeight)
        {
            // Limit the position to the maximum height
            newY = maxHeight;
            moveSpeed = 0;
        }
    
        // Apply the new position
        transform.GetComponent<RectTransform>().anchoredPosition = new Vector2(transform.GetComponent<RectTransform>().anchoredPosition.x, newY);
    }


    

    void MoveDown()
    {
        // Move the object downward along the Y-axis
        transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
    }
}
