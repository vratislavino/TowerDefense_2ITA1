using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointProvider : MonoBehaviour
{
    List<Transform> waypoints;

    void Start()
    {
        waypoints = new List<Transform>();
        for(int i = 0; i < transform.childCount; i++)
        {
            waypoints.Add(transform.GetChild(i));
        }
    }

    public Transform GetNextWaypoint(Transform current = null)
    {

    } 
}
