using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flame : MonoBehaviour
{
    [SerializeField] float power = 0.0f;
    [SerializeField] float timer = 0.0f;
    [SerializeField] int numberOfTimes = 0;

    void Start()
    {
        gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        var enemy = other.GetComponent<Enemy>();
        StartCoroutine(AttackEnemy(enemy));
    }

    private IEnumerator AttackEnemy(Enemy enemy)
    {
        for(int i=0; i<numberOfTimes; i++)
        {
            DecreaseHealth(enemy);
            yield return new WaitForSeconds(timer);
        }
    }

    private void DecreaseHealth(Enemy enemy)
    {
        float actualHealth = enemy.GetHealth();
        actualHealth -= power;
        enemy.SetHealth(actualHealth);
    }
}
