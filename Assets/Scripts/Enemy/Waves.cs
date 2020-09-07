using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Waves : MonoBehaviour
{
    [Header("Configurations")]
    [SerializeField] List<Wave> waves = null;
    [SerializeField] float delayTime;

    [Header("Wave Panel")]
    [SerializeField] GameObject wavePanel = null;
    [SerializeField] float panelTime = 0.0f;

    private int noOfWaves;

    void Start()
    {
        wavePanel.SetActive(false);
        noOfWaves = waves.Count;
        StartCoroutine(InstantiateNewWave());
    }

    private IEnumerator InstantiateNewWave()
    {
        while(noOfWaves > 0)
        {
            StartCoroutine(ShowWavePanel(waves.Count - noOfWaves + 1));
            Wave currentWave = waves[waves.Count - noOfWaves];
            float totalTime = currentWave.GetNoOfEnemies() * currentWave.GetTimeBetweenEnemies() + delayTime;
            StartCoroutine(currentWave.InstantiateRandomEnemies());
            noOfWaves -= 1;
            yield return new WaitForSeconds(totalTime);
        }
    }

    private IEnumerator ShowWavePanel(int currentWave)
    {
        wavePanel.transform.GetChild(0).GetComponent<Text>().text = "Wave " + currentWave + "/" + waves.Count;
        wavePanel.SetActive(true);
        yield return new WaitForSeconds(panelTime);
        wavePanel.SetActive(false);
        yield return new WaitForSeconds(panelTime);
        wavePanel.SetActive(true);
        yield return new WaitForSeconds(panelTime);
        wavePanel.SetActive(false);
        yield return new WaitForSeconds(panelTime);
        wavePanel.SetActive(true);
        yield return new WaitForSeconds(panelTime);
        wavePanel.SetActive(false);
        yield return new WaitForSeconds(panelTime);
        wavePanel.SetActive(true);
        yield return new WaitForSeconds(panelTime);
        wavePanel.SetActive(false);
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
