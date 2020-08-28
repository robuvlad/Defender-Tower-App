using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttacked : MonoBehaviour
{
    private float Health;

    private const string TAG_PROJECTILE = "projectile";
    private const string IS_DYING_ANIMATOR_PARAM = "isDying";
    private const float TIME_TO_DIE = 2.0f;

    void Start()
    {
        Enemy enemy = gameObject.GetComponent<Enemy>() as Enemy;
        Health = enemy.GetHealth();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == TAG_PROJECTILE)
        {
            Health -= other.GetComponent<ProjectileConfig>().Damage;
            if (Health <= 0.0f)
            {
                var animator = GetComponent<Animator>();
                animator.SetBool(IS_DYING_ANIMATOR_PARAM, true);
                Destroy(this.gameObject, TIME_TO_DIE);
            }
            Destroy(other.gameObject);
        }
    }
}
