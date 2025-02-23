using UnityEngine;

public class Movement : MonoBehaviour // Standard boilerplate
{
    // Variable declaration
    public float speed = 5f;
    public float boundary = 10f;
    public KeyCode upKey = KeyCode.UpArrow;
    public KeyCode downKey = KeyCode.DownArrow;

    // Update is called once per frame
    void Update()
    {
        // GetAxis returns value in [-1, 1] depending on if player presses up or down arrow keys
        // Used GetKey for binary inputs and movement
        float move = 0f;
        if (Input.GetKey(upKey))
        {
            move = 1f;
        }
        else if (Input.GetKey(downKey))
        {
            move = -1f;
        }

        // Changes the position of the object this script is attached to
        transform.Translate(Vector3.up * move * speed * Time.deltaTime);

        Vector3 position = transform.position; // Gets the current position of the object
        position.y = Mathf.Clamp(position.y, -boundary, boundary); // Restricts the y position of the object
        transform.position = position; // Sets the position of the object to the new position
    }
}
