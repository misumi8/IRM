using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class lHand : MonoBehaviour
{
    public ActionBasedController leftHandController;
    private Animator animator;
    private bool onceGrabbed = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (leftHandController.selectAction.action.ReadValue<float>() > 0.1f)
        {
            Debug.Log("Right hand grabbing");
            if (onceGrabbed)
            {
                animator.ResetTrigger("lGrabTriggerStop");
                animator.SetTrigger("lGrabTrigger");
                onceGrabbed = false;
            }
            /*WaitAnimation(0.17f);
            animator.ResetTrigger("rGrabTrigger");
            animator.SetTrigger("rGrabTriggerStop");*/
        }
        if (leftHandController.selectAction.action.ReadValue<float>() <= 0.1f)
        {
            onceGrabbed = true;
            animator.ResetTrigger("lGrabTrigger");
            animator.SetTrigger("lGrabTriggerStop");
        }
    }

    IEnumerator WaitAnimation(float time)
    {
        Debug.Log("Left hand waiting");
        yield return new WaitForSeconds(time);
    }
}
