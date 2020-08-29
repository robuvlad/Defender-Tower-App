using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaypoints : MonoBehaviour
{
    [SerializeField] List<Transform> waypoints = null;
    [SerializeField] List<Enemy> enemies = null;

    private Transform[] currentPoints = null;
    private int[] indexPoints = null;

    void Start()
    {
        InitializePoints();
    }

    void Update()
    {
        MoveTowardsNextPoints();
        UpdateCurrentPoints();
    }

    private void InitializePoints()
    {
        currentPoints = new Transform[enemies.Count];
        indexPoints = new int[enemies.Count];
        for (int i = 0; i < enemies.Count; i++)
        {
            indexPoints[i] = 0;
            currentPoints[i] = waypoints[indexPoints[i]];
        }
    }

    private void MoveTowardsNextPoints()
    {
        for(int i=0; i<enemies.Count; i++)
        {
            if (enemies[i] != null && enemies[i].GetHealth() > 0.0f)
            {
                var enemyComponent = enemies[i].GetComponent<Enemy>() as Enemy;
                float distanceDelta = Time.deltaTime * enemyComponent.GetSpeed();
                enemies[i].transform.position = Vector3.MoveTowards(enemies[i].transform.position, currentPoints[i].position, distanceDelta);
            }
        }
    }

    private void UpdateCurrentPoints()
    {
        for(int i=0; i<currentPoints.Length; i++)
        {
            if (enemies[i] != null && enemies[i].transform.position == currentPoints[i].position) //enemy can be destroyed => null
            {
                if (indexPoints[i] + 1 < waypoints.Count)
                {
                    currentPoints[i] = waypoints[indexPoints[i] + 1];
                    indexPoints[i] += 1;
                }
            }
        }
    }

    public List<Enemy> GetEnemies()
    {
        return enemies;
    }
}
