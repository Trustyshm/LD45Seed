using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanPickup : MonoBehaviour
{
    public GameObject pickUp;
    public GameObject wateringCan;

    public GameObject canPlayer;
    private bool notPickedUp;



    // Start is called before the first frame update
    void Start()
    {
        notPickedUp = true;

    }



    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (notPickedUp == true)
            {
                pickUp.SetActive(true);
            }


        }
    }


    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {

            pickUp.SetActive(false);
        }
    }

    private void Update()
    {
        if (pickUp.activeSelf)
        {
            if (notPickedUp == true)
            {
                if (Input.GetKeyDown("f"))
                {
                    pickUp.SetActive(false);
                    Destroy(wateringCan);
                    canPlayer.SetActive(true);
                    notPickedUp = false;



                }
            }

        }
    }
}
