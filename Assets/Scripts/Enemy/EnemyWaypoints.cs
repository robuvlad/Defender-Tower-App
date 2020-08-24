using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaypoints : MonoBehaviour
{
    [SerializeField] List<Transform> waypoints = null;
    [SerializeField] List<GameObject> enemies = null;

    private Transform currentPoint = null;

    void Start()
    {
        currentPoint = waypoints[0];
    }

    void Update()
    {
        MoveTowardsNextPoint();
        UpdateCurrentPoint();
    }

    private void MoveTowardsNextPoint()
    {
        for(int i=0; i<enemies.Count; i++)
        {
            var enemyComponent = enemies[i].GetComponent<IEnemy>() as IEnemy;
            float distanceDelta = Time.deltaTime * enemyComponent.Speed;
            enemies[i].transform.position = Vector3.MoveTowards(enemies[i].transform.position, currentPoint.position, distanceDelta);
        }
    }

    private void UpdateCurrentPoint()
    {
        for(int i=0; i<waypoints.Capacity - 1; i++)
        {
            if (waypoints[i] == currentPoint)
            {
                currentPoint = waypoints[i + 1];
            }
        }
    }
}
