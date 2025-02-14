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

            // Get the score manager to increment score 
            if (collision.gameObject.name == "Goal2")
            {
                ScoreManager.instance.AddScore("Player 1");
            }
            else if (collision.gameObject.name == "Goal1")
            {
                ScoreManager.instance.AddScore("Player 2");
            }
        }
    }

    private IEnumerator Wait() // Coroutine must return type IEnumerator
    {
        yield return new WaitForSeconds(respawn); // Wait 'respawn' seconds
        speed = initialSpeed;
        transform.position = Vector3.zero;
    }
}
