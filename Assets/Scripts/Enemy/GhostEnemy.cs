using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostEnemy : Enemy
{
    [SerializeField] float normalTime = 0.0f;
    [SerializeField] float ghostTime = 0.0f;
    [SerializeField] bool isGhost = false;

    private float ghostTimeSwitcher = 0.0f;
    private bool isNormal = true;

    void Update()
    {
        GhostSwitcher();
    }

    private void GhostSwitcher()
    {
        ghostTimeSwitcher += Time.deltaTime;
        if (isNormal == true)
        {
            if (ghostTimeSwitcher >= normalTime)
            {
                SwitchToGhost();
            }
        }
        else
        {
            if (ghostTimeSwitcher >= ghostTime)
            {
                SwitchToNormal();
            }
        }
    }

    private void SwitchToNormal()
    {
        ResetGhostTimeSwitcher();
        isNormal = true;
        GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
        SetIsGhost(false);
    }

    private void SwitchToGhost()
    {
        ResetGhostTimeSwitcher();
        isNormal = false;
        GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 80);
        SetIsGhost(true);
    }

    private void ResetGhostTimeSwitcher()
    {
        ghostTimeSwitcher = 0.0f;
    }

    public float GetGhostTime()
    {
        return ghostTime;
    }

    public void SetGhostTime(float time)
    {
        ghostTime = time;
    }

    public bool IsGhost()
    {
        return isGhost;
    }

    public void SetIsGhost(bool itIsGhost)
    {
        isGhost = itIsGhost;
    }
}
