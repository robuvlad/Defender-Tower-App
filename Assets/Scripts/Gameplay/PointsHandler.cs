using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsHandler : MonoBehaviour
{
    [SerializeField] int totalPoints = 0;
    [SerializeField] Text pointsText = null;

    void Update()
    {
        pointsText.text = totalPoints.ToString();
    }

    public float GetTotalPoints()
    {
        return totalPoints;
    }

    public void SetPoints(int points)
    {
        this.totalPoints = points;
    }

    public void IncreasePoints(int points)
    {
        totalPoints += points;
    }

    public void DecreasePoints(int points)
    {
        if (totalPoints >= points)
        {
            totalPoints -= points;
        }
    }
}
