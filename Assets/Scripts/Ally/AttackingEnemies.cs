using Assets.Scripts.Ally;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackingEnemies : MonoBehaviour, IAlly
{
    [SerializeField] float radius = 0.0f;

    [Range(0, 50)]
    private int segments = 150;
    private LineRenderer line = null;
    private Collider2D firstCollider = null;

    private const float line_width = 0.03f;
    private const float max_degrees = 360.0f;
    private const float speed = 3.0f;

    public float Range
    {
        get => radius;
        set => radius= value;
    }

    void Start()
    {
        InitializeLindeRenderer();
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
            for(int i=0; i< enemies.Capacity; i++)
            {
                bool isInRange = false;
                for(int j=0; j<colliders.Length; j++)
                {
                    if (colliders[j].gameObject == enemies[i])
                    {
                        Collider2D enemyCollider = enemies[i].GetComponent<Collider2D>() as Collider2D;
                        RotateTowards(enemyCollider);
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

    private void RotateTowards(Collider2D targetCollider)
    {
        Vector3 targ = targetCollider.transform.position;
        targ.z = 0f;

        Vector3 objectPos = transform.position;
        targ.x = targ.x - objectPos.x;
        targ.y = targ.y - objectPos.y;

        float angle = Mathf.Atan2(targ.y, targ.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    private void InitializeLindeRenderer()
    {
        line = GetComponent<LineRenderer>();
        line.positionCount = segments + 1;
        line.useWorldSpace = false;
        line.startWidth = line_width;
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

            angle += (max_degrees / segments);
        }
    }
}
