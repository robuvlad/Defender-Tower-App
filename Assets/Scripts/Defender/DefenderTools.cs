using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderTools : MonoBehaviour
{
    [Header("Upper Points Text")]
    [SerializeField] GameObject text = null;

    private GameObject defender = null;
    private Defender upgradeDefender = null;

    private const string ARROW_TAG = "arrow";
    private const string SELL_TAG = "sell";

    private void OnMouseDown()
    {
        if (gameObject.tag == ARROW_TAG)
        {
            Upgrade();
        }
        if (gameObject.tag == SELL_TAG)
        {
            SetHasDefenderPlace();
            Sell();
        }
    }

    private void Upgrade()
    {
        if (defender != null)
        {
            Vector3 pos = defender.transform.position;
            var points = FindObjectOfType<PointsHandler>();
            if (upgradeDefender != null && points.GetTotalPoints() >= upgradeDefender.GetPoints())
            {
                Transform parentPlace = defender.transform.parent;
                Destroy(defender);
                Defender upgradeDefenderPrefab = Instantiate(upgradeDefender, pos, Quaternion.identity) as Defender;
                upgradeDefenderPrefab.transform.SetParent(parentPlace.transform);
                points.DecreasePoints(upgradeDefenderPrefab.GetPoints());
                HideAllInstances();
                PlayAudio();
            }
        }
    }

    private void SetHasDefenderPlace()
    {
        if (defender != null)
        {
            Transform parentPlace = defender.transform.parent;
            var place = parentPlace.gameObject.GetComponent<PositionDefenders>();
            place.SetHasDefender(false);
        }
    }

    private void Sell()
    {
        if (defender != null)
        {
            var points = FindObjectOfType<PointsHandler>();
            int sellPoints = defender.GetComponent<Defender>().GetSellPoints();
            points.IncreasePoints(sellPoints);
            Destroy(defender);
            HideAllInstances();
            PlayAudio();
        }
    }

    public void SetDefender(GameObject def, Defender upgradeDef, GameObject textUpgrade, GameObject textSell)
    {
        this.defender = def;
        this.upgradeDefender = upgradeDef;
        ShowTexts(textUpgrade, textSell);
    }

    public void ShowColor()
    {
        GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
    }

    public void HideColor()
    {
        DestroyTexts();
        GetComponent<SpriteRenderer>().color = new Color32(50, 50, 50, 255);
    }

    private void HideAllInstances()
    {
        var tools = FindObjectsOfType<DefenderTools>();
        foreach(DefenderTools tool in tools)
        {
            tool.HideColor();
        }
    }

    private void ShowTexts(GameObject textUpgrade, GameObject textSell)
    {
        if (defender != null)
        {
            if (gameObject.tag == ARROW_TAG)
            {
                var textUpgradePref = Instantiate(textUpgrade, text.transform.position, Quaternion.identity);
                textUpgradePref.transform.parent = text.transform;
            }
            if (gameObject.tag == SELL_TAG)
            {
                var textSellPref = Instantiate(textSell, text.transform.position, Quaternion.identity);
                textSellPref.transform.parent = text.transform;
            }
        }
    }

    private void DestroyTexts()
    {
        var tools = FindObjectsOfType<DefenderTools>();
        foreach(DefenderTools tool in tools)
        {
            foreach(Transform child in text.transform)
            {
                Destroy(child.gameObject);
            }
        }
    }

    private void PlayAudio()
    {
        var audio = GetComponent<AudioSource>();
        audio.volume = PlayerPrefsController.GetSoundsPrefs();
        audio.Play();
    }
}
