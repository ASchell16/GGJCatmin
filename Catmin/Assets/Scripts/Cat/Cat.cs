using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Cat : MonoBehaviour
{
    public enum State { Idle, Follow, Interact }
    private Coroutine updateTarget = default;
    public UnityEngine.AI.NavMeshAgent agent = default;
    public State state = default;
    //public InteractiveObject objective;
    public bool isFlying;
    public bool isGettingIntoPosition;

    public GameObject riggedCat;
    //private Rigidbody[] riggedCatBones;
    public GameObject ragdollCat;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    }
    public void SetTarget(Transform target, float updateTime = 1f)
    {
        
        ragdollCat.transform.position = transform.position;
        riggedCat.transform.position = transform.position;
        riggedCat.SetActive(true);
        ragdollCat.SetActive(false);


        state = State.Follow;
        agent.stoppingDistance = 1f;
        agent.enabled = true;

        if (updateTarget != null)
            StopCoroutine(updateTarget);

        WaitForSeconds wait = new WaitForSeconds(updateTime);
        updateTarget = StartCoroutine(UpdateTarget());

        IEnumerator UpdateTarget()
        {
            while (true)
            {
                if(agent.enabled)
                    agent.SetDestination(target.position);
                yield return wait;
            }
        }
    }
    public void Throw(Vector3 target, float time, float delay)
    {

        riggedCat.SetActive(false);
        ragdollCat.SetActive(true);

        isFlying = true;
        state = State.Idle;
        
        agent.stoppingDistance = 0f;
        agent.enabled = false;
        riggedCat.transform.position = transform.position;
        ragdollCat.transform.position = transform.position;

        transform.DOJump(target, 5, 1, time).SetDelay(delay).SetEase(Ease.Linear).OnComplete(() =>
        {
            isFlying = false;
            CheckInteraction();
            target.y+=0.5f;
            transform.position = target;
            ragdollCat.transform.position = target;
            riggedCat.transform.position = target;
        });

        transform.LookAt(new Vector3(target.x, transform.position.y, target.z));

    }
    void CheckInteraction()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 1f);

        if (colliders.Length == 0)
            return;

        foreach (Collider collider in colliders)
        {
            /*if (collider.GetComponent<InteractiveObject>() && collider.GetComponent<NavMeshAgent>().enabled)
            {
                objective = collider.GetComponent<InteractiveObject>();
                objective.AssignPikmin();
                StartCoroutine(GetInPosition());

                break;
            }*/
        }

        //OnEndThrow.Invoke(0);

        /*IEnumerator GetInPosition()
        {
            isGettingIntoPosition = true;

            agent.SetDestination(objective.GetPositon());
            yield return new WaitUntil(() => agent.IsDone());
            agent.enabled = false;
            state = State.Interact;

            if (objective != null)
            {
                transform.parent = objective.transform;
                transform.DOLookAt(new Vector3(objective.transform.position.x, transform.position.y, objective.transform.position.z), .2f);
            }

            isGettingIntoPosition = false;
        }*/
    }

}
