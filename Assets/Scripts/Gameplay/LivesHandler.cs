using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesHandler : MonoBehaviour
{
    [SerializeField] int totalLives = 0;
    [SerializeField] Text livesText = null;

    private int maximumLives = 0;

    void Start()
    {
        maximumLives = totalLives;
    }

    void Update()
    {
        livesText.text = totalLives.ToString();
    }

    public int GetTotalLives()
    {
        return totalLives;
    }

    public void SetLives(int lives)
    {
        this.totalLives = lives;
    }

    public void DecreaseLives(int lives)
    {
        if (totalLives >= lives)
        {
            totalLives -= lives;
        }
    }

    public int GetMaximumLives()
    {
        return maximumLives;
    }
}
