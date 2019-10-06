using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunWander : MonoBehaviour
{
    public float speed;
    public Transform[] wanderSpots;
    private int randomSpot;
    private float waitTime;
    public float startWaitTime;




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



    }
}
