using Assets.Scripts.Projectiles;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileConfig : MonoBehaviour, IProjectile
{
    [SerializeField] float projectileSpeed = 0.0f;
    [SerializeField] float projectileDamage = 0.0f;

    public float Speed {
        get => projectileSpeed;
        set => projectileSpeed = value;
    }

    public float Damage {
        get => projectileDamage;
        set => projectileDamage = value;
    }
}
