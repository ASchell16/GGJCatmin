using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using UnityEngine.UI;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    [SerializeField] private GridLayoutGroup CatCounterParent = null;
    [SerializeField] private CatCounter CatCountBasePrefab = null;
    [SerializeField] private Text FollowingCatsCount = null;
    [SerializeField] private Text ZoneName = null;
    private ZoneManager currentZone;
    private GridLayoutGroup gridToUseForCatIcons = null;

    public void SetUIForZone(ZoneManager zone)
    {
        currentZone = zone;
        if (gridToUseForCatIcons != null)
            Destroy(gridToUseForCatIcons.gameObject);
        CatCounterParent.gameObject.SetActive(true);
        gridToUseForCatIcons = Instantiate(CatCounterParent, CatCounterParent.transform.parent, true);
        CatCounterParent.gameObject.SetActive(false);
        for (int i = 0; i < currentZone.CatCount; i++)
        {
            var catPrefab = Instantiate(CatCountBasePrefab, gridToUseForCatIcons.transform, false);
            catPrefab.gameObject.SetActive(true);
            catPrefab.SetCatState(currentZone.CatsSaved >= currentZone.CatCount);
        }

        ZoneName.text = currentZone.ZoneName;
    }

    public void UpdateCatCount(CatManager catManager)
    {
        if (gridToUseForCatIcons != null)
            Destroy(gridToUseForCatIcons.gameObject);
        CatCounterParent.gameObject.SetActive(true);
        gridToUseForCatIcons = Instantiate(CatCounterParent, CatCounterParent.transform.parent, true);
        CatCounterParent.gameObject.SetActive(false);
        FollowingCatsCount.text = catManager.controlledCats.ToString();
        int foundCats = 0;
        for (int i = 0; i < currentZone.CatCount; i++)
        {
                var catPrefab = Instantiate(CatCountBasePrefab, gridToUseForCatIcons.transform, false);
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
