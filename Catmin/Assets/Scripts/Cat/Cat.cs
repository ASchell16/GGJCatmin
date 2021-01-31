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

    //[SerializeField] private CatFollowBehaviour followBehaviour;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetTarget(Transform target, float updateTime = 1f)
    {
        /*if (state == State.Interact)
        {
            transform.parent = null;
            agent.enabled = true;
            objective.ReleasePikmin();
            objective = null;
        }*/

        state = State.Follow;
        agent.stoppingDistance = 1f;
        agent.enabled = true;
        //OnStartFollow.Invoke(0);

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
        //OnStartThrow.Invoke(0);

        isFlying = true;
        state = State.Idle;

        /*if (updateTarget != null)
            StopCoroutine(updateTarget);
        */
        agent.stoppingDistance = 0f;
        agent.enabled = false;

        transform.DOJump(target, 5, 1, time).SetDelay(delay).SetEase(Ease.Linear).OnComplete(() =>
        {
            //agent.enabled = true;
            //agent.SetDestination(target);
            isFlying = false;
            CheckInteraction();

            //OnEndThrow.Invoke(0);
        });

        transform.LookAt(new Vector3(target.x, transform.position.y, target.z));
        //visualHandler.model.DOLocalRotate(new Vector3(360 * 3, 0, 0), time, RotateMode.LocalAxisAdd).SetDelay(delay);

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
