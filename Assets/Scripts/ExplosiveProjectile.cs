using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveProjectile : MonoBehaviour
{
    [HideInInspector]
    public EnemyStats target;
    public float speed;
    public int damage;
    public float range;

    public void SetData(EnemyStats target, float speed, int damage, float range)
    {
        this.target = target;
        this.speed = speed;
        this.damage = damage;
        this.range = range;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.target == null) return;
        var dir = this.target.transform.position - transform.position;
        dir.Normalize();

        var move = dir * Time.deltaTime * speed;
        transform.Translate(move);

        if (Vector3.Distance(transform.position, this.target.transform.position) < 0.01f)
        {
            Explode();
        }
    }

    private void Explode()
    {
        Destroy(gameObject);
        var enemies = Physics2D.OverlapCircleAll(transform.position, range);
        for (int i = 0; i < enemies.Length; i++)
        {
            var enemy = enemies[i].GetComponentInParent<EnemyStats>();
            if (enemy != null)
            {
                float dist = Vector3.Distance(enemy.transform.position, transform.position);
                int realDamage = (int)(((range - dist) / range) * damage);
                enemy.TakeDmg(realDamage);
            }
        }
    }
}
