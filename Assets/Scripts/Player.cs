using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 1.0f;
    private readonly float turnSide = 1;


    public EdgeCollider2D weapon;
    public EdgeCollider2D[] hiteEnemies = new EdgeCollider2D[10];
    public ContactFilter2D filter;
    public BattleSystem battle;
    public Weapon weaponProperty;
    
    
    void Start()
    {
        weapon = GetComponentInChildren<EdgeCollider2D>();
        weaponProperty = new Weapon
        {
            attackRate = 3,
            forceAttack = 2
        };
    }

    
    void Update()
    {
        PlayerMovement();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
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

   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Weapon"))
        {
            Debug.Log("Вы насле дамаг");
        }
    }

    private void Attack()
    {
        {
            battle.MakeAttack(weapon, hiteEnemies, filter, weaponProperty);
        }
    }
}
