using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    // ����� ������
    // ��������� �����(����� ������)
    // ������� ����(����� ������)
    // 
    public void MakeAttack(EdgeCollider2D weapon, EdgeCollider2D[] hitEnemies, ContactFilter2D filter, Preference pref)
    {
        //��� �� ��� ����� Collider ������ ������� ����
        weapon.OverlapCollider(filter, hitEnemies);
        for (int i = 0; i < hitEnemies.Length; i++)
        {
            if (hitEnemies[i] == null)
                continue;

            //make something who collide
            DealDamage(hitEnemies[i], pref);
        }
    }

    protected void DealDamage(Collider2D collide, Preference pref)
    {
        if (collide.CompareTag("Enemy"))
        {
            Preference enemyPref = collide.GetComponent<Enemy>().enemyPreference;
            ReciveDamage(pref.currentHp, pref.damage, enemyPref, collide);
      
        }
    }
    private void ReciveDamage(int currentHp, int damage, Preference pref, Collider2D collide)
    {
        //���� �� ���� ����� Collider ������ �������� ����
        if (pref.currentHp <= 0)
        {
            Destroy(collide.gameObject);
        }
        else
        {
            
           pref.currentHp -= damage;
            Debug.Log(collide.gameObject);
        }

        

    }
}
