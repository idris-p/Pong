using System.Collections;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float speed = 5f;
    public float respawn = 3f;
    float moveX;
    float moveY;
    float initialSpeed;

    void Start()
    {
        initialSpeed = speed;
        
        // Randomly choose the direction of the ball between 1 and -1
        moveX = Random.Range(0, 2) == 0 ? 1f : -1f;
        moveY = Random.Range(0, 2) == 0 ? 1f : -1f;
    }
    void Update()
    {
        transform.Translate(Vector3.right * moveX * speed * Time.deltaTime);
        transform.Translate(Vector3.up * moveY * speed * Time.deltaTime);
    }

    // Called when the ball partakes in a collision
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Paddle")
        {
            moveX *= -1f;
            speed += 0.5f;
        }

        if (collision.gameObject.tag == "Wall")
        {
            moveY *= -1f;
        }

        if (collision.gameObject.tag == "Goal")
        {
            // Call coroutine to run simultaneously
            StartCoroutine(Wait());
        }
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(respawn); // Wait 5 seconds
        speed = initialSpeed;
        transform.position = Vector3.zero;
    }
}
