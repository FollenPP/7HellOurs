using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour

{
    public int hitpoint = 10;
    public int maxHitpoint = 10;
    private float pushForce = 1.0f;
    private float immuneTime = 1.0f;
    protected float lastImmune;

    protected virtual void ReceiveDamage(Damage dmg)
    {
        if (Time.time - lastImmune > immuneTime)
        {
            lastImmune = Time.time;
            hitpoint -= dmg.damage;

            if (hitpoint <= 0)
            {
                hitpoint = 0;
                Death();
            }
        }
           
    }

    private void Death()
    {
        Destroy(gameObject);

    }
}

