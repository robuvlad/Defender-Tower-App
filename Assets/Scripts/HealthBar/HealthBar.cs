using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Enemy enemy = null;
    [SerializeField] GameObject bar = null;

    private GameObject barSprite = null;

    private byte red = 0;
    private byte  green = 255;
    private byte blue = 0;

    private float maxHealth;

    void Start()
    {
        maxHealth = enemy.GetHealth();
        barSprite = bar.transform.GetChild(0).gameObject;
    }

    void Update()
    {
        float health = enemy.GetHealth();
        ShowHealthBar(health);
        ChangeColorBasedOnHealth(health);
    }

    private void ShowHealthBar(float health)
    {
        if (health >= 0.0f)
        {
            float normalizedHealth = NormalizedHealth(health);
            bar.transform.localScale = new Vector2(normalizedHealth, 1.0f);
        }
    }

    private float NormalizedHealth(float actualHealth)
    {
        return actualHealth / maxHealth;
    }

    private void ChangeColorBasedOnHealth(float health)
    {
        NormalizedColor(health);
        var sprite = barSprite.GetComponent<SpriteRenderer>() as SpriteRenderer;
        sprite.color = new Color32(red, green, blue, 255);
    }

    private void NormalizedColor(float health)
    {
        if (health >= maxHealth / 2)
        {
            red = (byte)((255 - (health / maxHealth) * 255) * 2);
        } else
        {
            green = (byte)((health / maxHealth) * 255 * 2);
        }
    }
}
