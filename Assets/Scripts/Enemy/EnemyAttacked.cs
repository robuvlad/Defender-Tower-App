using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttacked : MonoBehaviour
{
    [SerializeField] float timeToDie = 1.0f;

    private Enemy enemy = null;

    private const string TAG_PROJECTILE = "projectile";
    private const string IS_DYING_ANIMATOR_PARAM = "isDying";

    void Start()
    {
        enemy = gameObject.GetComponent<Enemy>() as Enemy;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == TAG_PROJECTILE)
        {
            float newHealth = enemy.GetHealth() - other.GetComponent<ProjectileConfig>().Damage;
            enemy.SetHealth(newHealth);
            if (enemy.GetHealth() <= 0.0f)
            {
                var animator = GetComponent<Animator>();
                animator.SetBool(IS_DYING_ANIMATOR_PARAM, true);
                Destroy(this.gameObject, timeToDie);
            }
            Destroy(other.gameObject);
        }
    }
}
