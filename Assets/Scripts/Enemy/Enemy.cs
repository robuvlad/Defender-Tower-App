using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float health = 0.0f;
    [SerializeField] float speed = 0.0f;
    [SerializeField] int points = 0;

    public void SetHealth(float h)
    {
        this.health = h;
    }

    public void SetSpeed(float s)
    {
        this.speed = s;
    }

    public float GetHealth()
    {
        return health;
    }

    public float GetSpeed()
    {
        return speed;
    }

    public int GetPoints()
    {
        return points;
    }

    public void SetPoints(int p)
    {
        this.points = p;
    }
}
