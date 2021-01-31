using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    [SerializeField] private GameUI UI = null;
    [SerializeField] private ZoneManager[] Zones = null;

    [SerializeField] private ZoneManager StarterZone = null;

    [SerializeField] private CatManager catManager = null;
    
    // Start is called before the first frame update
    void Start()
    {
        SetupUIForZone(StarterZone);
        catManager.CatThrown += OnCatThrown;
        catManager.CatRecalled += OnCatRecalled;
    }

    private void OnDestroy()
    {
        if (catManager != null)
        {
            catManager.CatThrown -= OnCatThrown;
            catManager.CatRecalled -= OnCatRecalled;
        }
    }

    public void SetupUIForZone(ZoneManager zone)
    {
        UI.SetUIForZone(zone);
    }

    private void OnCatThrown()
    {
        UI.UpdateCatCount(catManager);
    }

    private void OnCatRecalled()
    {
        UI.UpdateCatCount(catManager);
    }
}
