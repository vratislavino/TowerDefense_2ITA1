using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Transform currentWaypoint;
    [SerializeField]
    private float speed = 1;

    Animator animator;

    void Start()
    {
        currentWaypoint = WaypointProvider.Instance.GetNextWaypoint();
        animator = GetComponentInChildren<Animator>();
        animator.SetInteger("State", 3);
    }

    // Update is called once per frame
    void Update()
    {
        var dir = currentWaypoint.position - transform.position;
        dir.Normalize();

        var move = dir * Time.deltaTime * speed;
        transform.Translate(move);

        if(Vector3.Distance(transform.position, currentWaypoint.position) < 0.01f) {
            currentWaypoint = WaypointProvider.Instance.GetNextWaypoint(currentWaypoint);
            if(currentWaypoint == null)
            {
                // TODO damage to players base
                Destroy(gameObject);
            }
        }
    }
}
