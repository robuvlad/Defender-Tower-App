using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySnail : MonoBehaviour, IEnemy
{
    [SerializeField] float enemyHealth = 0.0f;
    [SerializeField] float enemySpeed = 0.0f;

    private const string TAG_PROJECTILE = "projectile";

    public float Health {
        get => enemyHealth;
        set => enemyHealth = value;
    }

    public float Speed {
        get => enemySpeed;
        set => enemySpeed = value;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == TAG_PROJECTILE)
        {
            Health -= other.GetComponent<ProjectileConfig>().Damage;
            if (Health <= 0.0f)
            {
                Destroy(this.gameObject);
            }
            //Destroy(other.gameObject);
        }
    }
}
