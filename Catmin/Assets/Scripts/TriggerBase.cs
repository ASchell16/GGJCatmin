using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBase : MonoBehaviour
{
    [SerializeField] private Animator Animator = null;

    [SerializeField] private bool openDoor = false;
    [SerializeField] private string animationName;
    [SerializeField] private string triggerOnTagEnter;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(triggerOnTagEnter))
        {
            if (openDoor)
            {
                Animator.Play(animationName);
            }
        }
    }
    
}
