using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAttacked : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] float timeToDie = 1.0f;

    [Header("UI Points Text")]
    [SerializeField] GameObject pointsText = null;
    [SerializeField] float pointsTime = 0.0f;

    private Enemy enemy = null;
    private PointsHandler points = null;
    private bool isAlreadyDead = false;

    private const string TAG_PROJECTILE = "projectile";
    private const string TAG_FLAME = "flame";
    private const string IS_DYING_ANIMATOR_PARAM = "isDying";

    void Start()
    {
        enemy = gameObject.GetComponent<Enemy>() as Enemy;
        points = FindObjectOfType<PointsHandler>() as PointsHandler;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == TAG_PROJECTILE)
        {
            HandleProjectile(other);
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == TAG_FLAME)
        {
            HandleFlame(other);
        }
    }

    private void HandleProjectile(Collider2D other)
    {
        float newHealth = enemy.GetHealth() - other.GetComponent<Projectile>().GetProjectileDamage();
        enemy.SetHealth(newHealth);
        if (enemy.GetHealth() <= 0.0f && !isAlreadyDead)
        {
            isAlreadyDead = true;
            var animator = GetComponent<Animator>();
            animator.SetBool(IS_DYING_ANIMATOR_PARAM, true);
            points.IncreasePoints(enemy.GetPoints());
            ShowPoints();
            var collider = GetComponent<PolygonCollider2D>();
            Destroy(collider);
            Destroy(this.gameObject, timeToDie);
        }
    }

    private void ShowPoints()
    {
        var pointsT = Instantiate(pointsText, gameObject.transform.position, Quaternion.identity);
        Destroy(pointsT, pointsTime);
    }

    private void HandleFlame(Collider2D other)
    {
        var flame = other.GetComponent<Flame>();
        var power = flame.GetPower();
        DecreaseHealth(power);
        if (enemy.GetHealth() <= 0.0f && !isAlreadyDead)
        {
            isAlreadyDead = true;
            var animator = GetComponent<Animator>();
            animator.SetBool(IS_DYING_ANIMATOR_PARAM, true);
            points.IncreasePoints(enemy.GetPoints());
            ShowPoints();
            var collider = GetComponent<CircleCollider2D>();
            Destroy(collider);
            Destroy(this.gameObject, timeToDie);
        }
    }

    private void DecreaseHealth(float power)
    {
        float newHealth = enemy.GetHealth() - power;
        enemy.SetHealth(newHealth);
    }
}
