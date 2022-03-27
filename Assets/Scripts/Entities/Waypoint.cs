using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{

    [System.Serializable]
    public class NextWaypointPair
    {
        public GameObject waypoint;
        public float probability;
    }

    public NextWaypointPair[] nextWaypoints;

    public GameObject getNextWaypoint()
    {
        float flag = Random.Range(0f, 1f);
        float prob = 0f;
        foreach (var entry in nextWaypoints) {
            if (flag >= prob && flag <= (prob + entry.probability))
            {
                return entry.waypoint;
            }
            prob += entry.probability;
        }
        return nextWaypoints[nextWaypoints.Length - 1].waypoint;
    }
}
