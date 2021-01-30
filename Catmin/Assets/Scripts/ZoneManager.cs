using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneManager : MonoBehaviour
{
    [SerializeField] private string zoneName = "";
    public string ZoneName => zoneName;
    [SerializeField] private GameStateManager GameStateManager = null;
    [SerializeField] private GameObject[] CatsToSave = null;
    public int CatCount => CatsToSave.Length;
    private int catsSaved = 0;
    public int CatsSaved => catsSaved;

    public void CatSaved()
    {
        catsSaved++;
    }

    public void SetUIForZone()
    {
        GameStateManager.SetupUIForZone(this);
    }
}
