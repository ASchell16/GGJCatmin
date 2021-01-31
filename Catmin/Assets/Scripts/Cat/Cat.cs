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
    private Quaternion flyingSpin;
    private float spinSpeed = 0.01f;
    public bool isGettingIntoPosition;

    public bool isFound = false;
    //[SerializeField] private CatFollowBehaviour followBehaviour;
    public GameObject riggedCat;

    private Rigidbody[] riggedCatBones;
    //private List<> ragdollCatBoneTransforms;
    public GameObject ragdollCat;


    // Start is called before the first frame update
    void Start()
    {
        riggedCatBones = ragdollCat.GetComponentsInChildren<Rigidbody>(true);

        foreach(Rigidbody rb in riggedCatBones)
        {
            rb.isKinematic = true;
            rb.useGravity = false;
        }

        //ragdollCatBoneTransforms = ragdollCat.GetComponentsInChildren<Transform>(true);
        /*foreach(Transform tr in ragdollCat.GetComponentsInChildren<Transform>(true))
        {
            ragdollCatBoneTransforms.Add(new Transform(tr));
        }*/
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(isFlying)
        {
            ragdollCat.transform.Rotate(flyingSpin.eulerAngles*spinSpeed);
        }
    }
    public void SetTarget(Transform target, float updateTime = 1f)
    {
        
        riggedCat.SetActive(true);
        
        ragdollCat.transform.position = transform.position;
        riggedCat.transform.position = transform.position;
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
                if (agent.enabled)
                {
                    agent.SetDestination(target.position);
                }

                yield return wait;
            }
        }
    }
    public void Throw(Vector3 target, float time, float delay)
    {
        ragdollCat.SetActive(true);

        isFlying = true;
        state = State.Idle;
        
        agent.stoppingDistance = 0f;
        agent.enabled = false;

        flyingSpin = Random.rotation;

        foreach(Rigidbody rb in riggedCatBones)
        {
            rb.AddTorque(new Vector3(Random.Range(100, 500),Random.Range(100, 500),Random.Range(100, 500)));
            
            rb.isKinematic = true;
            rb.useGravity = false;
        }

        riggedCat.transform.localPosition = Vector3.zero;
        ragdollCat.transform.localPosition = Vector3.zero;



        riggedCat.SetActive(false);

        transform.DOJump(target, 5, 1, time).SetDelay(delay).SetEase(Ease.Linear).OnComplete(() =>
        {
            isFlying = false;
            CheckInteraction();
            //target.y+=0.5f;
            //transform.position = ragdollCat.transform.position;
            ragdollCat.transform.position = transform.position;
            //ragdollCat.transform.GetChild(0).transform.position = transform.position;
            riggedCat.transform.position = ragdollCat.transform.position;
            foreach(Rigidbody rb in riggedCatBones)
            {
                rb.isKinematic = false;
                rb.useGravity = true;
            }
            //riggedCat.SetActive(true);
            //ragdollCat.SetActive(false);
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
