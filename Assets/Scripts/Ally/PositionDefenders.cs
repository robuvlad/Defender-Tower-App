using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionDefenders : MonoBehaviour
{
    [SerializeField] GameObject defender = null;

    private Vector3 SPAWNING_POINT = new Vector3(0, 0, -1);

    private void OnMouseDown()
    {
        SpawnDefender();
    }

    private void SpawnDefender()
    {
        GameObject newDefender = Instantiate(defender, transform.position + SPAWNING_POINT, Quaternion.identity) as GameObject;
    }
}
