using UnityEngine;

public class MoveZigZag : MonoBehaviour
{
    public float speed = 10.0f; // Speed of bug
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
