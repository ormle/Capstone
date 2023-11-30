using System;
using TouchScript.Gestures;
using UnityEngine;

public class Descriptions : MonoBehaviour
{
    public float moveSpeed = 10f; // Initial speed
    private bool movingUp = false;
    private bool movingDown = false;
    private bool isTapped = false;
    private float minHeight = -10f;
    private float maxHeight = -0.2f;

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
            //movingUp = true;
            //movingDown = false;
        }

        // Check for button click to move the object down
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            //movingUp = false;
            //movingDown = true;
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

    void TapGesture_Tapped(object sender, EventArgs e)
    {
        //movingUp = false;
        //movingDown = true;
    }

    public void MoveUp()
    {
        movingUp = true;
        movingDown = false;
        
        float upMoveSpeed = moveSpeed;

        // Move the object upward along the Y-axis
        float newY = transform.position.y + (Vector3.up.y * upMoveSpeed * Time.deltaTime);

        // Apply the new position smoothly
        transform.position = new Vector3(transform.position.x, Mathf.MoveTowards(transform.position.y, newY, upMoveSpeed * Time.deltaTime), transform.position.z);

        // Check if the object has reached the maximum height
        if (newY >= maxHeight)
        {
            // Stop moving up
            movingUp = false;
        }
    }

    public void MoveDown()
    {
        movingUp = false;
        movingDown = true;
        
        float downMoveSpeed = moveSpeed;

        // Move the object downward along the Y-axis
        float newY = transform.position.y - (downMoveSpeed * Time.deltaTime);

        // Apply the new position smoothly
        transform.position = new Vector3(transform.position.x, Mathf.MoveTowards(transform.position.y, newY, downMoveSpeed * Time.deltaTime), transform.position.z);

        // Check if the object has reached the minimum height
        if (newY <= minHeight)
        {
            // Stop moving down
            movingDown = false;
        }
    }
}
