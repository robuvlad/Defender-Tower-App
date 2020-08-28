using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float health = 0.0f;
    [SerializeField] float speed = 0.0f;

    public float GetHealth()
    {
        return health;
    }

    public float GetSpeed()
    {
        return speed;
    }
}
