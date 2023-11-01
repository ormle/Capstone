using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed = 3.0f; // Speed of bug
    private Vector3 direction; // Movement direction
    public int leftright;

    private void Start()
    {
        direction = Vector3.up;
        
    }

    private void Update()
    {
        // Move the bug in the specified direction
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
