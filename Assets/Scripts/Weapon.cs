using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Collidable
{
    public int attackDamage = 10;
    private float attackRate = 2f;
    private float nextAttackTime = 0f; 
    public int forceAttack;

    private int weaponLvl = 0;
    private SpriteRenderer weaponSprite;

    public override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                base.Update();
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
        
        
        
    }

    public override void OnCollide(Collider2D coll)
    {
        if (coll.CompareTag("Enemy"))
        {
            Damage dmg = new Damage
            {
                damage = attackDamage,
                origin = transform.position,
                pushForce = forceAttack
            };

            coll.SendMessage("ReceiveDamage", dmg);
            Debug.Log(coll.name);
        }
    }

    private void Attack()
    {

    }

}
