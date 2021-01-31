using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CatManager : MonoBehaviour
{
    private List<Cat> allCats = new List<Cat>();
    [Header("Positioning")]
    public Transform catThrowPosition;
    [Header("Targeting")]
    [SerializeField] private Transform target = default;
    [SerializeField] private CatPointer controller = default;
    [SerializeField] private float selectionRadius = 3;
    public int controlledCats = 0;

    // Start is called before the first frame update
    void Start()
    {
        allCats.AddRange(Object.FindObjectsOfType<Cat>());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            foreach (Cat cat in allCats)
            {
                if (cat.state == Cat.State.Follow && Vector3.Distance(cat.transform.position, transform.position) < 2)
                {
                    cat.agent.enabled = false;
                    float delay = .05f;
                    cat.transform.DOMove(catThrowPosition.position,delay);

                    cat.Throw(controller.hitPoint, .5f, delay);
                    controlledCats--;

                    /*pikminThrow.Invoke(controller.hitPoint);
                    pikminFollow.Invoke(controlledPikmin);*/
                    break;
                }
            }
        }

        if (Input.GetMouseButton(1))
        {
            foreach (Cat cat in allCats)
            {
                if (Vector3.Distance(cat.transform.position, controller.hitPoint) < selectionRadius)
                {
                    if (cat.state != Cat.State.Follow)
                    {
                        if (cat.isFlying || cat.isGettingIntoPosition)
                            return;

                        cat.SetTarget(transform, 0.25f);
                        controlledCats++;
                        //pikminFollow.Invoke(controlledPikmin);
                    }
                }
            }
        }
    }
}
