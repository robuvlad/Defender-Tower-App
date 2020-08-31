using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaypoints : MonoBehaviour
{
    [SerializeField] List<Transform> waypoints = null;
    [SerializeField] Enemy enemy = null;
    //[SerializeField] List<Enemy> enemiesPrefabs = null;
    //[SerializeField] List<float> probabilities = null;
    [SerializeField] int numberOfEnemies = 0;
    [SerializeField] float timeBetweenEnemies = 0.0f;

    private List<Enemy> enemies = null;
    private Transform[] currentPoints = null;
    private int[] indexPoints = null;

    void Start()
    {
        enemies = new List<Enemy>();
        StartCoroutine(InstantiateRandomEnemies());
        InitializePoints();
    }

    void Update()
    {
        MoveTowardsNextPoints();
        UpdateCurrentPoints();
    }

    private IEnumerator InstantiateRandomEnemies()
    {
        while (numberOfEnemies > 1)
        {
            var newEnemy = Instantiate(enemy, waypoints[0].transform.position, Quaternion.identity);
            enemies.Add(newEnemy);
            numberOfEnemies -= 1;
            yield return new WaitForSeconds(timeBetweenEnemies);
        }
    }

    /*
    private void InstantiateRandomEnemy()
    {
        for(int i=0; i<enemiesPrefabs.Count; i++)
        {

        }
    }*/

    private void InitializePoints()
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
        for(int i=0; i<enemies.Count; i++)
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
