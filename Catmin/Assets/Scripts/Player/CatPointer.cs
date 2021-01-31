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
            target.position = hit.point + targetOffset;
            hitPoint = hit.point;
            target.forward = Vector3.Lerp(target.forward, hit.normal, .3f);

        }
    }
}
