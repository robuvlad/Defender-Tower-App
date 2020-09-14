using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellDefender : MonoBehaviour
{
    private void OnMouseDown()
    {
        var points = FindObjectOfType<PointsHandler>();
        var defender = gameObject.transform.parent.parent.gameObject.GetComponent<Defender>();
        var defenderGameObject = gameObject.transform.parent.parent.gameObject.GetComponent<Defender>().gameObject;
        if (defender != null)
        {
            int sellPoints = defender.GetSellPoints();
            points.IncreasePoints(sellPoints);
            Destroy(defenderGameObject);
        }
    }
}
