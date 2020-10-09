using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    [SerializeField] int score = 0;
    [SerializeField] int[] buy = null;
    [SerializeField] int[] sell = null;
    [SerializeField] float[] timer = null;
    [SerializeField] float[] radius = null;
    [SerializeField] float[] damage = null;
    [SerializeField] string name = null;

    public void SetScore(int s)
    {
        score = s;
    }

    public int GetScore()
    {
        return score;
    }

    public int[] GetBuy()
    {
        return buy;
    }

    public int[] GetSell()
    {
        return sell;
    }

    public float[] GetTimer()
    {
        return timer;
    }

    public float[] GetRadius()
    {
        return radius;
    }

    public float[] GetDamage()
    {
        return damage;
    }

    public string GetName()
    {
        return name;
    }
}
