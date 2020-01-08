using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    float speed;

    float radius;
    Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        speed = 5f;
        direction = Vector2.one.normalized;
        radius = transform.localScale.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
        speed += 1 * Time.deltaTime;
         // game borders
        if (transform.position.y < GameHandler.bottomLeft.y + radius && direction.y < 0) {
            direction.y = -direction.y;
        }
        if (transform.position.y > GameHandler.topRight.y - radius && direction.y > 0) {
            direction.y = -direction.y;
        }

        // Game over 
        if (transform.position.x < GameHandler.bottomLeft.x + radius && direction.x < 0) {
            Debug.Log("Right wins!");
            Time.timeScale = 0;
            enabled = false;
        }
        if (transform.position.x > GameHandler.topRight.x - radius && direction.x > 0) {
            Debug.Log("Left wins!");
            Time.timeScale = 0;
            enabled = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Paddle") {
            bool isRight = other.GetComponent<Paddle>().isRight;

            if (isRight == true && direction.x > 0) {
                direction.x = -direction.x;
            }
            if (isRight == false && direction.x < 0) {
                direction.x = -direction.x;
            }
        }
    }
}
