using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    [SerializeField] int score = 0;

    public void SetScore(int s)
    {
        score = s;
    }

    public int GetScore()
    {
        return score;
    }
}
