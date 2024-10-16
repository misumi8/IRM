using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHit : MonoBehaviour
{
    private int hitCount = 0;
    private bool canRegHit = true;

    void Start()
    {

    }

    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("golfClub") && canRegHit)
        {
            hitCount++;
            canRegHit = false;
            StartCoroutine(sleepFor());
        }
    }

    IEnumerator sleepFor()
    {
        yield return new WaitForSeconds(1.0f);
        canRegHit = true;
    }

    public int getHitCount()
    {
        return hitCount;
    }
    public void setHitCount(int newHitCount)
    {
        hitCount = newHitCount;
    }

}
