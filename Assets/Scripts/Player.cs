using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 1.0f;
    private readonly float turnSide = 1;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 movePlayer = new Vector2(horizontalInput, verticalInput);
        transform.Translate(movePlayer  * speed * Time.deltaTime);
        TurnPlayer(horizontalInput);
    }

    void TurnPlayer(float horizontalInput)
    {
        if (horizontalInput > 0)
        {
            transform.localScale = new Vector2(turnSide, 1);
        }
        else if (horizontalInput < 0)
        {
            transform.localScale = new Vector2(-turnSide, 1);
        }
    }
}
