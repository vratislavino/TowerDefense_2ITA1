using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LaserTower : SingleAttackTower
{
    LineRenderer lineRenderer;
    EnemyStats currentEnemy;

    protected override void Start()
    {
        base.Start();
        lineRenderer = GetComponent<LineRenderer>();
    }


    protected override void Attack(EnemyStats enemy)
    {
        currentEnemy = enemy;
        enemy.TakeDmg(damage);
    }

    private void Update()
    {
        if (currentEnemy != null)
        {
            lineRenderer.SetPositions(new Vector3[] {
                transform.position,
                currentEnemy.transform.position
            });
        }
    }

    protected override void EnemyOutOfRange(EnemyStats enemy)
    {
        base.EnemyOutOfRange(enemy);
        currentEnemy = null;
        lineRenderer.SetPositions(new Vector3[] {
            transform.position,
            transform.position,
        });
    }

}
