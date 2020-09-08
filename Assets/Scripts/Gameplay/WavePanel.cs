using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WavePanel : MonoBehaviour
{
    [Header("Wave Panel")]
    [SerializeField] GameObject wavePanel = null;
    [SerializeField] float panelTime = 0.0f;

    private AudioSource audioWaveChanged = null;

    void Start()
    {
        audioWaveChanged = GetComponent<AudioSource>() as AudioSource;
        wavePanel.SetActive(false);
    }

    public IEnumerator ShowWavePanel(int currentWave, int totalWaves)
    {
        PlayAudio();
        wavePanel.transform.GetChild(0).GetComponent<Text>().text = "Wave " + currentWave + "/" + totalWaves;
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

    private void PlayAudio()
    {
        if (audioWaveChanged != null)
        {
            audioWaveChanged.Play();
        }
    }
}
