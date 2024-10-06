using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDistanceCalculator : MonoBehaviour
{
    public GameObject imageTarget1;
    public GameObject imageTarget2;
    public Animator animator1;
    public Animator animator2;

    void Start()
    {
        imageTarget1 = GameObject.Find("ImageTarget1");
        imageTarget2 = GameObject.Find("ImageTarget2");

        if (imageTarget1 == null)
        {
            Debug.LogError("imageTarget1 not found");
        }
        if (imageTarget2 == null)
        {
            Debug.LogError("imageTarget1 not found");
        }

        animator1 = imageTarget1.GetComponentInChildren<Animator>();
        Debug.Log("ANIMATOR1 NAME: " + animator1.name);
        animator2 = imageTarget2.GetComponentInChildren<Animator>();
        Debug.Log("ANIMATOR2 NAME: " + animator2.name);

        if (animator1 == null)
        {
            Debug.LogError("animator1 not found!");
        }
        if (animator2 == null)
        {
            Debug.LogError("animator2 not found!");
        }
    }

    void Update()
    {
        Vector3 pos1 = imageTarget1.transform.position;
        Vector3 pos2 = imageTarget2.transform.position;

        float distance = Vector3.Distance(pos1, pos2);
        Debug.Log("Distance between image targets: " + distance + " m.");
        if(distance < 0.3f)
        {
            Debug.Log("Distance < 0.3m");
            animator1.SetTrigger("TrAttackCactus");
            animator2.SetTrigger("TrAttackMush");
        }
        else
        {
            Debug.Log("Distance > 0.3m");
            animator1.ResetTrigger("TrAttackCactus");
            animator2.ResetTrigger("TrAttackMush");
        }

    }
}
