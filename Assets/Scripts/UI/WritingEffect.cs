using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WritingEffect : MonoBehaviour
{
    [SerializeField] Text soundsUI;
    [SerializeField] float waitTime = 0.1f;

    private const string stringText = "Founder: Robu Vlad \n Sounds from: Zapslat.com \n Zombies from: rileygombart \n";

    void Start()
    {
        StartCoroutine(WriteSoundsText());
    }

    private IEnumerator WriteSoundsText()
    {
        yield return new WaitForSeconds(waitTime * 2);
        foreach(char c in stringText)
        {
            soundsUI.text += c;
            yield return new WaitForSeconds(waitTime);
        }
    }
}
