using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CatLegRotator : MonoBehaviour
{
    public List<Transform> backLegAnchors;
    public List<Transform> frontLegAnchors;
    NavMeshAgent navAgent;
    public float rotationSpeed;
    public float multiplier;

    private void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        if (backLegAnchors.Count > 1 && frontLegAnchors.Count > 1)
        {
            backLegAnchors[0].RotateAround(backLegAnchors[0].position, transform.right, 180f);
            frontLegAnchors[1].RotateAround(frontLegAnchors[1].position, transform.right, 180f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Transform t in backLegAnchors)
        {
            t.RotateAround(t.position, transform.right, Time.deltaTime * rotationSpeed * multiplier);
        }
        foreach (Transform t in frontLegAnchors)
        {
            t.RotateAround(t.position, transform.right, Time.deltaTime * rotationSpeed * multiplier);
        }
    }
}
