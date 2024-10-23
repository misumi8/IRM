using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OnBallFellIntoHole : MonoBehaviour
{
    public TextMeshProUGUI text;
    public TextMeshProUGUI score;
    public OnHit onBallHit;
    public GameObject objectToSpawn;
    private GameObject spawnedObject;

    void Start()
    {

    }

    void Update()
    {
        score.text = "Score: " + onBallHit.getHitCount().ToString();
        score.color = Color.black;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("golfBall"))
        {
            text.text = "You win!\nNumber of hits: " + onBallHit.getHitCount().ToString();
            onBallHit.setHitCount(0);
            spawnedObject = Instantiate(objectToSpawn, transform.position, Quaternion.identity);
            StartCoroutine(sleepAndClear(2.5f));
        }
    }

    IEnumerator sleepAndClear(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        text.text = "";

    }
}
