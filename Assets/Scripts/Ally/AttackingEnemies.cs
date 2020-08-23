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

    private const float line_width = 0.03f;
    private const float max_degrees = 360.0f;

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
            Vector3 diff = Camera.main.ScreenToWorldPoint(colliders[0].transform.position) - transform.position;
            diff.Normalize();
            Debug.Log(colliders[0].transform.position);
            Debug.Log(colliders.Length);

            float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
        }
        catch(IndexOutOfRangeException e)
        {

        }
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
