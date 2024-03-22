using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WaypointProvider : MonoBehaviour
{
    private static WaypointProvider instance;
    public static WaypointProvider Instance => instance;

    List<Transform> waypoints;

    private void Awake()
    {
        instance = this;
        InitWaypoints();
    }

    void InitWaypoints()
    {
        waypoints = new List<Transform>();
        for(int i = 0; i < transform.childCount; i++)
        {
            waypoints.Add(transform.GetChild(i));
        }
    }

    public Transform GetNextWaypoint(Transform current = null)
    {
        if (current == null) return waypoints.First();

        var index = waypoints.IndexOf(current);
        index++;

        if(index == waypoints.Count)
        {
            return null;
        }

        return waypoints[index];
    } 
}
