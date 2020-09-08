using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenderSelection : MonoBehaviour
{
    [SerializeField] Defender defender = null;
    [SerializeField] bool isAvailable = false;

    [Header("Lock / Unlock Level")]
    [SerializeField] Text unlockMessage = null;
    [SerializeField] int levelUnlocked;
    [SerializeField] GameObject panel = null;

    private float timeToUnlock = 1.0f;

    void Start()
    {
        panel.SetActive(false);
    }

    private void OnMouseDown()
    {
        if (isAvailable)
        {
            var defenders = FindObjectsOfType<DefenderSelection>();
            foreach (DefenderSelection def in defenders)
            {
                if (def.IsAvailable())
                    def.GetComponent<SpriteRenderer>().color = new Color32(100, 100, 100, 255);
                else
                    def.GetComponent<SpriteRenderer>().color = new Color32(0, 0, 0, 255);
            }
            GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
            PlaceDefender(defender);
        }
        else
        {
            unlockMessage.text = "First unlock level " + levelUnlocked;
            StartCoroutine(ShowUnlockMessage());
        }
        
    }

    private void PlaceDefender(Defender def)
    {
        var positionDefs = FindObjectsOfType<PositionDefenders>();
        foreach(PositionDefenders pos in positionDefs)
        {
            pos.SetDefender(def);
        }
    }

    private IEnumerator ShowUnlockMessage()
    {
        panel.SetActive(true);
        yield return new WaitForSeconds(timeToUnlock);
        panel.SetActive(false);
    }

    public bool IsAvailable()
    {
        return isAvailable;
    }
}
