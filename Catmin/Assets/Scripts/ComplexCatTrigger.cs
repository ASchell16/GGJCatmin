using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ComplexCatTrigger : MonoBehaviour
{
    [SerializeField] private int requiredCatCount;
    [SerializeField] private Text catCountFloatingText;
    [SerializeField] private Animator Animator = null;
    [SerializeField] private string animationName;
    [SerializeField] private string triggerOnTagEnter;

    [SerializeField] private int catsInColliderCount;
    private const string formattedString = "{0}\n-\n{1}";
    private void Start()
    {
        catCountFloatingText.text = string.Format(formattedString, catsInColliderCount, requiredCatCount);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(triggerOnTagEnter))
        {
            catsInColliderCount++;
            catCountFloatingText.text = string.Format(formattedString, catsInColliderCount, requiredCatCount);
            if (catsInColliderCount >= requiredCatCount)
            {
                // at this point maybe wait for them to all be in the idle state?
                Animator.Play(animationName);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(triggerOnTagEnter))
        {
            catsInColliderCount--;
            catCountFloatingText.text = string.Format(formattedString, catsInColliderCount, requiredCatCount);
        }
    }
}
