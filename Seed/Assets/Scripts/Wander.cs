using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : MonoBehaviour
{
    public float speed;
    public Transform[] wanderSpots;
    private int randomSpot;
    private float waitTime;
    public float startWaitTime;

    public GameObject feedText;


    void Start()
    {
        randomSpot = Random.Range(0, wanderSpots.Length);
        waitTime = startWaitTime;
    
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, wanderSpots[randomSpot].position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, wanderSpots[randomSpot].position) < 0.2f)
        {
            if(waitTime <= 0)
            {
                randomSpot = Random.Range(0, wanderSpots.Length);
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }

        if (transform.position.x - wanderSpots[randomSpot].position.x < -0.1f)
        {
            transform.rotation = Quaternion.identity;
            feedText.transform.rotation = Quaternion.Euler(0, 0, 0);
            GameObject.FindGameObjectWithTag("PoopContainer").transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (transform.position.x - wanderSpots[randomSpot].position.x > 0.1f)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            feedText.transform.rotation = Quaternion.Euler(0, 0, 0);
            GameObject.FindGameObjectWithTag("PoopContainer").transform.rotation = Quaternion.Euler(0, 0, 0);

        }

    }
}
