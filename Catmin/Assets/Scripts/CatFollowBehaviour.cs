using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CatFollowBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject PlaceToNavigateTo = null;

    [SerializeField] private NavMeshAgent NavAgent = null;

    private void Update()
    {
        NavAgent.destination = PlaceToNavigateTo.transform.position;
    }
}
