using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] List<Image> images = null;

    private int score = 0;

    public void IncreaseScore(int number)
    {
        score += number;
    }

    public void DecreaseScore(int number)
    {
        if (score >= number)
        {
            score -= number;
        }
    }

    public int GetScore()
    {
        return score;
    }

    public void SetScore(int s)
    {
        score = s;
    }
}
