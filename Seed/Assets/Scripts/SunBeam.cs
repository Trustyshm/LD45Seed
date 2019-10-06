using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunBeam : MonoBehaviour
{
    public float speed;
    public Transform playerHere;
    private float waitTime;
    private float startWaitTime;

    public GameObject sunBeam;
    private GameObject theBeam;
    public Transform shoot;
    private GameObject theSunBeam;
    public GameObject leafPower;
    public AudioClip clip;
    public AudioSource source;




    void Start()
    {
        startWaitTime = Random.Range(1, 2.5f);
        waitTime = startWaitTime;
        playerHere.transform.position = GameObject.FindGameObjectWithTag("Player").transform.position;
        source.clip = clip;

    }

    private void Update()
    {
        theSunBeam = GameObject.FindGameObjectWithTag("SunBeam");
        if (GameObject.FindGameObjectsWithTag("SunBeam").Length <1)
        {
            if (waitTime <= 0)
            {
                Instantiate(sunBeam, shoot.position, playerHere.transform.rotation);
                playerHere.transform.position = GameObject.FindGameObjectWithTag("Player").transform.position;
                source.PlayOneShot(source.clip);
                startWaitTime = Random.Range(1, 2.5f);
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
        
        if (theSunBeam != null)
        {
            if (Vector2.Distance(theSunBeam.transform.position, playerHere.transform.position) <= 0.05f)
            {
                Debug.Log("this happened");
                Instantiate(leafPower, theSunBeam.transform.position, transform.rotation);
                Destroy(theSunBeam);

            }

        }
        









    }
}
