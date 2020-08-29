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

    private const float MAP_MAX = 50.0f;
    private const float MAP_MIN = -50.0f;

    public float Range
    {
        get => radius;
        set => radius= value;
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
                        Enemy en = enemies[i].GetComponent<Enemy>() as Enemy;
                        if (en.GetHealth() >= 0.0f)
                        {
                            Collider2D enemyCollider = enemies[i].GetComponent<Collider2D>() as Collider2D;
                            RotateTowards(enemyCollider, this.gameObject);
                            Shoot(enemies[i]);
                            isInRange = true;
                            break;
                        }
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
            Vector2 relativePoint = transform.right * projectileSpeed;
            projectile.GetComponent<Rigidbody2D>().velocity = relativePoint;
            localTime = timer;
        }
    }

    private void OnMouseDown()
    {
        if (line == null)
        {
            InitializeLineRenderer();
            CreateLineRenderer();
        }
        else
        {
            DestroyLineRenderer();
        }
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
        line.positionCount = segments + 1;
        for (int i = 0; i < (segments + 1); i++)
        {
            x = Mathf.Sin(Mathf.Deg2Rad * angle) * radius;
            y = Mathf.Cos(Mathf.Deg2Rad * angle) * radius;

            line.SetPosition(i, new Vector3(x, y, 0));

            angle += (MAX_DEGREES / segments);
        }
    }

    private void DestroyLineRenderer()
    {
        line.positionCount = 1;
        line = null;
    }
}
