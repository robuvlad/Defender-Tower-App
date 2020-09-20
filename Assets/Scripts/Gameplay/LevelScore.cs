using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScore : MonoBehaviour
{
    [SerializeField] int scoreLevel = 0;

    public int GetScoreLevel()
    {
        return scoreLevel;
    }
}
