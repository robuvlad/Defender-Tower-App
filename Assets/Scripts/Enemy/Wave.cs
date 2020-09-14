using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    [Header("Enemy configuration")]
    [SerializeField] Enemy enemy = null;
    [SerializeField] int numberOfEnemies = 0;
    [SerializeField] float timeBetweenEnemies = 0.0f;

    private List<Enemy> enemies = null;
    private Transform[] currentPoints = null;
    private int[] indexPoints = null;
    private List<Transform> waypoints = null;

    private bool hasSpawnedFinished = false;

    void Start()
    {
        waypoints = FindObjectOfType<Waypoints>().GetWaypoints();
        enemies = new List<Enemy>();
        InitializePoints();
    }

    void Update()
    {
        MoveTowardsNextPoints();
        UpdateCurrentPoints();
    }

    public IEnumerator InstantiateRandomEnemies()
    {
        while (numberOfEnemies > 0)
        {
            var newEnemy = Instantiate(enemy, waypoints[0].transform.position, Quaternion.identity);
            enemies.Add(newEnemy);
            numberOfEnemies -= 1;
            yield return new WaitForSeconds(timeBetweenEnemies);
        }
        hasSpawnedFinished = true;
    }

    public void InitializePoints()
    {
        currentPoints = new Transform[numberOfEnemies];
        indexPoints = new int[numberOfEnemies];
        for (int i = 0; i < numberOfEnemies; i++)
        {
            indexPoints[i] = 0;
            currentPoints[i] = waypoints[indexPoints[i]];
        }
    }

    private void MoveTowardsNextPoints()
    {
        for (int i = 0; i < enemies.Count; i++)
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
        for (int i = 0; i < enemies.Count; i++)
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
    
    public float GetNoOfEnemies()
    {
        return numberOfEnemies;
    }

    public float GetTimeBetweenEnemies()
    {
        return timeBetweenEnemies;
    }

    public bool HasSpawnedFinished()
    {
        return hasSpawnedFinished;
    }
}
