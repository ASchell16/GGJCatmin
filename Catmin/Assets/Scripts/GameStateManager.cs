using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    [SerializeField] private ZoneManager[] Zones = null;

    [SerializeField] private ZoneManager StarterZone = null;
    // Start is called before the first frame update
    void Start()
    {
        StarterZone.SetUIForZone();
    }
}
