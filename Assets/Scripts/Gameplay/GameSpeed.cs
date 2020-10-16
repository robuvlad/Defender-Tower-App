using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSpeed : MonoBehaviour
{
    [SerializeField] Sprite mediumSpeedSprite = null;
    [SerializeField] Sprite maxSpeedSprite = null;

    private int speed = 0;

    private void OnMouseDown()
    {
        HandleGameSpeed();
    }

    private void HandleGameSpeed()
    {
        if (speed == 0)
        {
            ChangeTimeScale(1.5f);
            GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
        } else if (speed == 1)
        {
            ChangeTimeScale(2.0f);
            GetComponent<SpriteRenderer>().sprite = maxSpeedSprite;
            GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
        }
        else
        {
            ChangeTimeScale(1.0f);
            GetComponent<SpriteRenderer>().sprite = mediumSpeedSprite;
            GetComponent<SpriteRenderer>().color = new Color32(0, 0, 0, 255);
        }
        speed = (speed + 1) % 3;
    }

    private void ChangeTimeScale(float value)
    {
        Time.timeScale = value;
    }

    public float GetCurrentTimeScale()
    {
        if (speed == 0)
            return 1.0f;
        else if (speed == 1)
            return 1.5f;
        return 2.0f;
    }
}
