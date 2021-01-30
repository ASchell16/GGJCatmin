using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneManager : MonoBehaviour
{
    [SerializeField] private GameObject[] CatsToSave = null;
    public int CatCount => CatsToSave.Length;
    private int CatsSaved = 0;

    public void CatSaved()
    {
        CatsSaved++;
    }

    public void SetUIForZone()
    {
        
    }
}
