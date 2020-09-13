using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [Header("Setup config")]
    [SerializeField] float radius = 0.0f;
    [SerializeField] int points;

    [Header("Upgrade config")]
    [SerializeField] GameObject upgradeArrow = null;
    [SerializeField] Defender upgradeDefender = null;

    [Header("Line renderer config")]
    [SerializeField] float R;
    [SerializeField] float G;
    [SerializeField] float B;

    [Range(0, 50)]
    private int segments = 150;
    private LineRenderer line = null;

    private const float LINE_WIDTH = 0.03f;
    private const float MAX_DEGREES = 360.0f;

    private const float MAP_MAX = 50.0f;
    private const float MAP_MIN = -50.0f;

    private GameObject arrow = null;

    public float GetRadius()
    {
        return radius;
    }

    private void OnMouseDown()
    {
        if (line == null)
        {
            InitializeLineRenderer();
            CreateLineRenderer();
            ShowUpgradeArrow();
        }
        else
        {
            DestroyLineRenderer();
            DestroyUpgradeArrow();
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
        line.material.color = new Color(R, G, B);
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

    private void ShowUpgradeArrow()
    {
        arrow = Instantiate(upgradeArrow, gameObject.transform.position, Quaternion.identity);
        arrow.transform.parent = gameObject.transform;
    }

    private void DestroyUpgradeArrow()
    {
        Destroy(arrow);
    }

    public int GetPoints()
    {
        return points;
    }

    public Defender GetUpgradeDefender()
    {
        return upgradeDefender;
    }
}
