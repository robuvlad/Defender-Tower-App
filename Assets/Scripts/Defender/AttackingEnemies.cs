using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackingEnemies : MonoBehaviour
{
    [SerializeField] GameObject weapon = null;
    [SerializeField] GameObject spawnProjectile = null;
    [SerializeField] float timer = 0.0f;
    private float localTime = 0.0f;

    void Update()
    {
        CheckForEnemies();
    }

    private void CheckForEnemies()
    {
        float radius = gameObject.GetComponent<Defender>().GetRadius();
        Collider2D[] colliders = Physics2D.OverlapCircleAll(this.transform.position, radius);
        try
        {
            Wave enemy = GameObject.Find("Wave 1").GetComponent<Wave>();
            List<Enemy> enemies = enemy.GetEnemies();
            for(int i=0; i< enemies.Count; i++)
            {
                bool isInRange = false;
                for(int j=0; j<colliders.Length; j++)
                {
                    if (enemies[i] != null && colliders[j].gameObject == enemies[i].gameObject)
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

    private void Shoot(Enemy enemy)
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
}
