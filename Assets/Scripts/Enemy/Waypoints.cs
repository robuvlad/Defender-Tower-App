using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    [SerializeField] List<Transform> waypoints = null;
    

    public List<Transform> GetWaypoints()
    {
        return waypoints;
    }
}
