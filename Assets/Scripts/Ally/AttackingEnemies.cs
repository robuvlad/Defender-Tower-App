using Assets.Scripts.Ally;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackingEnemies : MonoBehaviour, IAlly
{
    [Header("Setup configuration")]
    [SerializeField] float radius = 0.0f;

    [SerializeField] GameObject weapon = null;
    [SerializeField] GameObject spawnProjectile = null;
    [SerializeField] float timer = 0.0f;
    private float localTime = 0.0f;

    [Range(0, 50)]
    private int segments = 150;
    private LineRenderer line = null;

    private const float LINE_WIDTH = 0.03f;
    private const float MAX_DEGREES = 360.0f;

    private const float MAP_MAX = 10.0f;
    private const float MAP_MIN = -10.0f;

    public float Range
    {
        get => radius;
        set => radius= value;
    }

    void Start()
    {
        InitializeLineRenderer();
        CreateLineRenderer();
    }

    void Update()
    {
        CheckForEnemies();
    }

    private void CheckForEnemies()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(this.transform.position, radius);
        try
        {
            EnemyWaypoints enemy = GameObject.Find("Waypoints").GetComponent<EnemyWaypoints>();
            List<GameObject> enemies = enemy.GetEnemies();
            for(int i=0; i< enemies.Count; i++)
            {
                bool isInRange = false;
                for(int j=0; j<colliders.Length; j++)
                {
                    if (colliders[j].gameObject == enemies[i])
                    {
                        Collider2D enemyCollider = enemies[i].GetComponent<Collider2D>() as Collider2D;
                        RotateTowards(enemyCollider, this.gameObject);
                        Shoot(enemies[i]);
                        isInRange = true;
                        break;
                    }
                }
                if (isInRange)
                    break;
            }
        }
        catch(IndexOutOfRangeException e)
        {

        }
    }

    private void RotateTowards(Collider2D targetCollider, GameObject from)
    {
        Vector3 targ = targetCollider.transform.position;
        targ.z = 0f;

        Vector3 objectPos = from.transform.position;
        targ.x = targ.x - objectPos.x;
        targ.y = targ.y - objectPos.y;

        float angle = Mathf.Atan2(targ.y, targ.x) * Mathf.Rad2Deg;
        from.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    private void Shoot(GameObject enemy)
    {
        localTime -= Time.deltaTime;
        if (localTime <= 0.0f)
        {
            GameObject projectile = Instantiate(weapon, spawnProjectile.transform.position, this.gameObject.transform.rotation);
            float projectileSpeed = projectile.GetComponent<ProjectileConfig>().Speed;
            float x_velocity = enemy.transform.position.x * projectileSpeed * Time.deltaTime;
            float y_velocity = enemy.transform.position.y * projectileSpeed * Time.deltaTime;
            Vector2 relativePoint = EstimateRelativePoint(x_velocity, y_velocity);
            Debug.Log(x_velocity + "  " + y_velocity + " | " + relativePoint.x + " " + relativePoint.y);
            projectile.GetComponent<Rigidbody2D>().velocity = relativePoint;
            //projectile.GetComponent<Rigidbody2D>().AddForce(relativePoint, ForceMode2D.Force);
            localTime = timer;
        }
    }

    private Vector2 EstimateRelativePoint(float x, float y)
    {
        if ((x >= 0 && y >= 0 && x <= y) || (x <= 0 && y >= 0 && -x <= y)) {
            return new Vector2(MAP_MAX / (y / x), MAP_MAX);
        }
        else if ((x <= 0 && y >= 0 && -x >= y) || (x <= 0 && y <= 0 && x <= y)) {
            return new Vector2(MAP_MIN, MAP_MIN * (y / x));
        }
        else if ((x <= 0 && y <= 0 && x >= y) || (x >= 0 && y <= 0 && x <= -y)) {
            return new Vector2(MAP_MIN / (y / x), MAP_MIN);
        }
        else
            return new Vector2(MAP_MAX, MAP_MAX * (y / x));
    }

    private void InitializeLineRenderer()
    {
        line = GetComponent<LineRenderer>();
        line.positionCount = segments + 1;
        line.useWorldSpace = false;
        line.startWidth = LINE_WIDTH;
    }

    private void CreateLineRenderer()
    {
        float x, y;
        float angle = 20f;
        for (int i = 0; i < (segments + 1); i++)
        {
            x = Mathf.Sin(Mathf.Deg2Rad * angle) * radius;
            y = Mathf.Cos(Mathf.Deg2Rad * angle) * radius;

            line.SetPosition(i, new Vector3(x, y, 0));

            angle += (MAX_DEGREES / segments);
        }
    }
}
