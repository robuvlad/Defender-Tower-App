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
            Destroy(other.gameObject);
        }
    }

    private void ShowPoints()
    {
        var pointsT = Instantiate(pointsText, gameObject.transform.position, Quaternion.identity);
        Destroy(pointsT, pointsTime);
    }
}
