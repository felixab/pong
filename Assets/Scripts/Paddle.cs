using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField]
    float speed;

    float height;

    string input;
    public bool isRight;

    // Start is called before the first frame update
    void Start()
    {
        height = transform.localScale.y;
        speed = 10f;
    }

    public void Init(bool isRightPaddle) {
        Vector2 pos = Vector2.zero;

        isRight = isRightPaddle;
        
        if (isRightPaddle) {
            pos = new Vector2(GameHandler.topRight.x - transform.localScale.x, 0);
            input = "PaddleRight";
        } else {
            pos = new Vector2(GameHandler.bottomLeft.x +  transform.localScale.x, 0);
            input = "PaddleLeft";
        }

        transform.position = pos;
        transform.name = input;
    }
    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxis(input) * Time.deltaTime * speed;

        // game borders
        if (transform.position.y < GameHandler.bottomLeft.y + height/2 && move < 0) {
            move = 0;
        }
        if (transform.position.y > GameHandler.topRight.y - height/2 && move > 0) {
            move = 0;
        }

        transform.Translate(move * Vector2.up);
    }
}
