using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarDisplay : MonoBehaviour
{
    [SerializeField] GameObject gold = null;
    [SerializeField] GameObject silver = null;
    [SerializeField] GameObject bronze = null;

    [SerializeField] List<GameObject> stars = null;

    void Start()
    {
        DisplayStars();
    }    

    private void DisplayStars()
    {
        int maxLevel = PlayerPrefsController.GetMaxLevel();
        for(int i = 0; i < maxLevel; i++)
        {
            DisplaySpecificStars(i);
        }
    }

    private void DisplaySpecificStars(int index)
    {
        int level = index + 1;
        int starPlace = PlayerPrefsController.GetStarPrefs(level);
        switch (starPlace)
        {
            case 1:
                InstantiateStars(gold, index);
                break;
            case 2:
                InstantiateStars(silver, index);
                break;
            case 3:
                InstantiateStars(bronze, index);
                break;
            default:
                break;
        }
    }

    private void InstantiateStars(GameObject starType, int index)
    {
        var starTypePrefab = Instantiate(starType, stars[index].transform.position, Quaternion.identity);
        starTypePrefab.transform.SetParent(stars[index].transform);
    }
}
