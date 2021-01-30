using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneTrigger : MonoBehaviour
{
    [SerializeField]
    private ZoneManager Zone = null;

    [SerializeField] private string triggerOnTagEnter = "Player";
    
    private void OnTriggerEnter(Collider other)
    {
        if (!string.IsNullOrEmpty(other.tag) && other.CompareTag(triggerOnTagEnter))
        {
           Zone.SetUIForZone();
        }
    }
}
