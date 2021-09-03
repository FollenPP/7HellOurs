using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Preference enemyPreference;
    public int maxHp;
    public int currentHp;
    public int damage;
    public int defence;
    public int pushForce;
    private void Start()
    {
        enemyPreference = new Preference
        {
            maxHp = maxHp,
            currentHp = currentHp,
            damage = damage,
            defence = defence,
            pushForce = pushForce
        };
    }
    
}
