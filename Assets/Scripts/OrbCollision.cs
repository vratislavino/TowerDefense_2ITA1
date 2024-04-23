using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbCollision : MonoBehaviour
{
    private int damage;

    public void SetDamage(int damage)
    {
        this.damage = damage;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        var enemy = other.gameObject.GetComponentInParent<EnemyStats>();
        if(enemy)
        {
            enemy.TakeDmg(damage);
        }
    }
}
