using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using UnityEngine.UI;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    [SerializeField] private Transform CatCounterParent = null;
    [SerializeField] private CatCounter CatCountBasePrefab = null;
    [SerializeField] private Text FollowingCatsCount = null;
    [SerializeField] private Text ZoneName = null;
    private ZoneManager currentZone;

    public void SetUIForZone(ZoneManager zone)
    {
        currentZone = zone;
        CatCounterParent.DetachChildren();
        for (int i = 0; i < currentZone.CatCount; i++)
        {
            var catPrefab = Instantiate(CatCountBasePrefab, CatCounterParent, false);
            catPrefab.gameObject.SetActive(true);
            catPrefab.SetCatState(currentZone.CatsSaved >= currentZone.CatCount);
        }

        ZoneName.text = currentZone.ZoneName;
    }

    public void UpdateCatCount(CatManager catManager)
    {
        FollowingCatsCount.text = catManager.controlledCats.ToString();
        int foundCats = 0;
        for (int i = 0; i < currentZone.CatCount; i++)
        {
                var catPrefab = Instantiate(CatCountBasePrefab, CatCounterParent, false);
                catPrefab.gameObject.SetActive(true);
                if (i < catManager.CatsList.Count)
                {
                    catPrefab.SetCatState(catManager.CatsList[i].isFound);
                }
                else
                {
                    catPrefab.SetCatState(false);
                }
        }
        currentZone.CatsSavedUpdate(foundCats);
    }
}
