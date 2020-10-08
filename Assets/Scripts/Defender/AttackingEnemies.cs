using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackingEnemies : MonoBehaviour
{
    [SerializeField] GameObject weapon = null;
    [SerializeField] GameObject spawnProjectile = null;
    [SerializeField] float timer = 0.0f;

    [Header("Timer between a number of projectiles")]
    [SerializeField] float timeBetweenMoreProj = 0.0f;
    [SerializeField] int shooterCounterProjectiles = 3;

    private float localTime = 0.0f;
    private string WAVE_TAG = "wave";
    private AudioSource audioShoot = null;

    private int shooterCounter = 0;

    void Start()
    {
        audioShoot = GetComponent<AudioSource>() as AudioSource;
        audioShoot.volume = PlayerPrefsController.GetSoundsPrefs();
    }

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
            GameObject[] waves = GameObject.FindGameObjectsWithTag(WAVE_TAG);
            for (int k = 0; k < waves.Length; k++)
            {
                bool isInRange = false;
                Wave enemy = waves[k].GetComponent<Wave>() as Wave;
                List<Enemy> enemies = enemy.GetEnemies();
                for (int i = 0; i < enemies.Count; i++)
                {
                    for (int j = 0; j < colliders.Length; j++)
                    {
                        if (enemies[i] != null && colliders[j].gameObject == enemies[i].gameObject)
                        {
                            Enemy en = enemies[i].GetComponent<Enemy>() as Enemy;
                            if (en.GetHealth() >= 0.0f)
                            {
                                GhostEnemy ghost = null;
                                if (en is GhostEnemy)
                                    ghost = en as GhostEnemy;
                                if (!(en is GhostEnemy) || (ghost != null && ghost.IsGhost() == false))
                                {
                                    Collider2D enemyCollider = enemies[i].GetComponent<Collider2D>() as Collider2D;
                                    RotateTowards(enemyCollider, this.gameObject);
                                    Shoot(enemies[i]);
                                    isInRange = true;
                                    break;
                                }
                            }
                        }
                    }
                    if (isInRange)
                        break;
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
            PlayAudio();
            float projectileSpeed = projectile.GetComponent<Projectile>().GetProjectileSpeed();
            Vector2 relativePoint = transform.right * projectileSpeed;
            projectile.GetComponent<Rigidbody2D>().velocity = relativePoint;
            localTime = timer;
            shooterCounter += 1;
            if (shooterCounter == shooterCounterProjectiles)
            {
                localTime = timer + timeBetweenMoreProj;
                shooterCounter -= shooterCounter;
            }
        }

    }

    private void PlayAudio()
    {
        if (audioShoot != null)
        {
            audioShoot.Play();
        }
    }

}
