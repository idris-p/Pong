using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float speed = 5f;
    public float boundary = 10f;
    float moveX = 1f;
    float moveY = 1f;

    void Update()
    {
        transform.Translate(Vector3.right * moveX * speed * Time.deltaTime);
        transform.Translate(Vector3.up * moveY * speed * Time.deltaTime);

        if (transform.position.y > boundary || transform.position.y < -boundary)
        {
            moveY *= -1f;
        }

        if (transform.position.x > 11f || transform.position.x < -11f)
        {
            moveX *= -1f;
        }
    }
}
