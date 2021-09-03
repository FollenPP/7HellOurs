using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    // Дамаг оружия
    // Получение урона(Дамаг оружия)
    // Нанести урон(Дамаг оружия)
    // 
    public void MakeAttack(EdgeCollider2D weapon, EdgeCollider2D[] hitEnemies, ContactFilter2D filter, Weapon weaponProperty)
    {
        //Все те кто задел Collider должны нанести урон
        weapon.OverlapCollider(filter, hitEnemies);
        for (int i = 0; i < hitEnemies.Length; i++)
        {
            if (hitEnemies[i] == null)
                continue;

            //make something who collide
            DealDamage(hitEnemies[i], weaponProperty);
        }
    }

    protected void DealDamage(Collider2D collide, Weapon weaponProperty)
    {
        if (collide.CompareTag("Enemy"))
        {
            Enemy enemy = collide.GetComponent<Enemy>();
            ReciveDamage(enemy.currentHp, weaponProperty.attackRate, enemy, collide);
      
        }
    }
    private void ReciveDamage(int currentHp, int damage, Enemy enemy, Collider2D collide)
    {
        //Всех те кого задел Collider должны получить урон
        if (enemy.currentHp <= 0)
        {
            Destroy(collide.gameObject);
        }
        else
        {
            
           enemy.currentHp -= damage;
        }

        

    }
}
