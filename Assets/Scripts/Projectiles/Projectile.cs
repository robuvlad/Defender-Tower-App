using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float projectileSpeed = 0.0f;
    [SerializeField] float projectileDamage = 0.0f;

    public float GetProjectileSpeed()
    {
        return projectileSpeed;
    }

    public void SetProjectileSpeed(float speed)
    {
        this.projectileSpeed = speed;
    }

    public float GetProjectileDamage()
    {
        return projectileDamage;
    }

    public void SetProjectileDamage(float damage)
    {
        this.projectileDamage = damage;
    }
}
