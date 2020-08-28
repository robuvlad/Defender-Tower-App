using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Enemy enemy = null;
    [SerializeField] GameObject bar = null;

    private float health;

    void Start()
    {
        health = enemy.GetHealth();
    }

    void Update()
    {
        ShowHealthBar();
    }

    private void ShowHealthBar()
    {
        float normalizedHealth = NormalizedHealth(enemy.GetHealth());
        bar.transform.localScale = new Vector2(normalizedHealth, 1.0f);
    }

    private float NormalizedHealth(float actualHealth)
    {
        return actualHealth / health;
    }
}
