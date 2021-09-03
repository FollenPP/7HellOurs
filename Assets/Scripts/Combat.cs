using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    //variables
    public float attackRate = 5f;
    float nextAttackTime = 0f;
    private int damage = 1;

    //filter
    private ContactFilter2D filter;

    //ref
    private Animator anim;
    private EdgeCollider2D weaponCollider;



    //Сделать лист
    private EdgeCollider2D[] hitEnemies = new EdgeCollider2D[10];

    public LayerMask enemyLayers;



    void Start()
    {
        anim = GetComponent<Animator>();
        weaponCollider = GetComponentInChildren<EdgeCollider2D>();

        //filter.SetLayerMask(enemyLayers);

    }


    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Attack();
            }
        }
    }

    void Attack()
    {
        //Set Animation
        anim.SetTrigger("isAttack");
        //count attackTime
        nextAttackTime = Time.time + 1.5f / attackRate;

        //Find who collide with Weapon
        weaponCollider.OverlapCollider(filter, hitEnemies);
        for (int i = 0; i < hitEnemies.Length; i++)
        {
            if (hitEnemies[i] == null)
                continue;

            //make something who collide
            OnCollide(hitEnemies[i]);
        }
    }

    protected virtual void OnCollide(Collider2D collide)
    {
        if (collide.CompareTag("Enemy"))
        {

            collide.GetComponent<Enemy>().ReceiveDamage(damage);
        }
    }

}
