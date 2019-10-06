using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowFeed : MonoBehaviour
{

    public GameObject playerGrass;
    public GameObject feed;
    public GameObject grassParticlesCow;
    private bool notFed;
    public GameObject poop;
    //public Rigidbody2D poopRB;
    public Transform butt;
    public GameObject cowFeedSound;
    public GameObject cowPoopSound;

    // Start is called before the first frame update
    void Start()
    {
        notFed = true;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (playerGrass.activeSelf)
            {
                if (notFed == true)
                {
                    feed.SetActive(true);
                }
            }
            


        }
    }


    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {

            feed.SetActive(false);
        }
    }

    private void Update()
    {
        if (feed.activeSelf)
        {
            if (Input.GetKeyDown("f"))
            {
                feed.SetActive(false);
                grassParticlesCow.SetActive(true);
                playerGrass.SetActive(false);
                notFed = false;
                cowFeedSound.SetActive(true);
                StartCoroutine(CowPoop());
                

                

            }
        }
    }

    IEnumerator CowPoop()
    {
        yield return new WaitForSeconds(1.2f);
        cowPoopSound.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        Instantiate(poop, butt.position, transform.rotation);
        
    }
}
