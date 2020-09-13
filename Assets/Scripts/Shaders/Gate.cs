using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    private const string ENEMY_TAG = "enemy";

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == ENEMY_TAG)
        {
            Destroy(other.gameObject);
            CheckForLives();
        }
    }

    private void CheckForLives()
    {
        var lives = FindObjectOfType<LivesHandler>();
        lives.DecreaseLives(1);
        if (lives.GetTotalLives() <= 0)
        {
            Debug.Log("Game Over!");
        }
    }
}
