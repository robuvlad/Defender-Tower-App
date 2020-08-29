using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSelection : MonoBehaviour
{
    [SerializeField] GameObject defender = null;

    private void OnMouseDown()
    {
        var defenders = FindObjectsOfType<DefenderSelection>();
        foreach(DefenderSelection defender in defenders)
        {
            defender.GetComponent<SpriteRenderer>().color = new Color32(38, 38, 38, 255);
        }
        GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
        PlaceDefender(defender);
    }

    private void PlaceDefender(GameObject def)
    {
        var positionDefs = FindObjectsOfType<PositionDefenders>();
        foreach(PositionDefenders pos in positionDefs)
        {
            pos.SetDefender(def);
        }
    }
}
