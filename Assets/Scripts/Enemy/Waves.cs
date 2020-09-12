using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waves : MonoBehaviour
{
    [Header("Configurations")]
    [SerializeField] List<Wave> waves = null;
    [SerializeField] float delayTime;

    private int noOfWaves;

    void Start()
    {
        noOfWaves = waves.Count;
        StartCoroutine(InstantiateNewWave());
    }

    private IEnumerator InstantiateNewWave()
    {
        while(noOfWaves > 0)
        {
            Wave currentWave = waves[waves.Count - noOfWaves];
            float totalTime = currentWave.GetNoOfEnemies() * currentWave.GetTimeBetweenEnemies() + delayTime;
            StartCoroutine(currentWave.InstantiateRandomEnemies());
            noOfWaves -= 1;
            yield return new WaitForSeconds(totalTime);
        }
    }

    public float GetDelayTime()
    {
        return delayTime;
    }

    public List<Wave> GetWaves()
    {
        return waves;
    }
}
