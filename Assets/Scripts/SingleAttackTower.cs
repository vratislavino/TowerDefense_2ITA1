using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class SingleAttackTower : Tower
{
    [SerializeField]
    protected float attackSpeed;

    [SerializeField]
    protected float range;

    [SerializeField]
    protected List<EnemyStats> enemiesInRange = new List<EnemyStats>();

    protected Animator animator;

    protected virtual void Start()
    {
        CircleCollider2D cc = GetComponent<CircleCollider2D>();
        cc.radius = range;

        animator = GetComponentInChildren<Animator>();

        StartCoroutine(AttackRoutine());
    }

    IEnumerator AttackRoutine()
    {
        while(true)
        {
            if(enemiesInRange.Count == 0) {
                yield return new WaitForEndOfFrame();
            } else
            {
                Attack(enemiesInRange.First());
                yield return new WaitForSeconds(attackSpeed);
            }
        }
    }

    protected abstract void Attack(EnemyStats enemy);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var enemy = collision.gameObject.GetComponentInParent<EnemyStats>();
        if (enemy != null) {
            enemiesInRange.Add(enemy);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        var enemy = collision.gameObject.GetComponentInParent<EnemyStats>();
        if (enemy != null)
        {
            EnemyOutOfRange(enemy);
        }
    }

    protected virtual void EnemyOutOfRange(EnemyStats enemy)
    {
        if (enemiesInRange.Contains(enemy))
        {
            enemiesInRange.Remove(enemy);
        }
    }
}
