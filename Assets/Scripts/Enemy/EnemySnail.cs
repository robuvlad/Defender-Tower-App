using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySnail : MonoBehaviour, IEnemy
{
    [SerializeField] float enemyHealth = 0.0f;
    [SerializeField] float enemySpeed = 0.0f;

    public float Health {
        get => enemyHealth;
        set => enemyHealth = value;
    }

    public float Speed {
        get => enemySpeed;
        set => enemySpeed = value;
    }

    void Start()
    {
        
    }
}
