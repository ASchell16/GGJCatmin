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

    public void SetUIForZone(ZoneManager zone)
    {
        CatCounterParent.DetachChildren();
        for (int i = 0; i < zone.CatCount; i++)
        {
            var catPrefab = Instantiate(CatCountBasePrefab, CatCounterParent, false);
            catPrefab.gameObject.SetActive(true);
            catPrefab.SetCatState(zone.CatsSaved >= zone.CatCount);
        }

        ZoneName.text = zone.ZoneName;
    }
}
