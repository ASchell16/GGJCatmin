using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBase : MonoBehaviour
{
    [SerializeField] private Animator Animator = null;

    [SerializeField] private string animationName;
    [SerializeField] private string triggerOnTagEnter;

    private void OnTriggerEnter(Collider other)
    {
        if (!string.IsNullOrEmpty(other.tag) && other.CompareTag(triggerOnTagEnter))
        {
            Animator.Play(animationName);
        }
    }
    
}
