using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using System.Threading.Tasks;
using System;

public class rHand : MonoBehaviour
{
    public ActionBasedController rightHandController;
    private Animator animator;
    private bool onceGrabbed = false;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (rightHandController.selectAction.action.ReadValue<float>() > 0.1f)
        {
            Debug.Log("Right hand grabbing");
            if (onceGrabbed) {
                animator.ResetTrigger("rGrabTriggerStop");
                animator.SetTrigger("rGrabTrigger");
                onceGrabbed = false;
            }
            /*WaitAnimation(0.17f);
            animator.ResetTrigger("rGrabTrigger");
            animator.SetTrigger("rGrabTriggerStop");*/
        }
        if(rightHandController.selectAction.action.ReadValue<float>() <= 0.1f){
            onceGrabbed = true;
            animator.ResetTrigger("rGrabTrigger");
            animator.SetTrigger("rGrabTriggerStop");
        }
    }

    IEnumerator WaitAnimation(float time)
    {
        Debug.Log("Right hand waiting");
        yield return new WaitForSeconds(time);
    }
}
