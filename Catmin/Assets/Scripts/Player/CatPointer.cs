using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatPointer : MonoBehaviour
{
    [HideInInspector] public Vector3 hitPoint = Vector3.zero;
    [SerializeField] private Transform follow = default;
    [SerializeField] private Vector3 followOffset = Vector3.zero;
    public Transform target = default;
    [SerializeField] private Vector3 targetOffset = Vector3.zero;
    public Camera cam;
    private LineRenderer line = default;
    const int linePoints = 5;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMousePosition();

    }

    void UpdateMousePosition()
    {
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            hitPoint = hit.point;
            target.position = hit.point + targetOffset;
            target.up = Vector3.Lerp(target.up, hit.normal, .3f);
            for (int i = 0; i < linePoints; i++)
            {
                Vector3 linePos = Vector3.Lerp(follow.position + followOffset, target.position, (float)i / 5f);
                //line.SetPosition(i, linePos);
            }
        }
    }
}
