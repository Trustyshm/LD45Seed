using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoopPickup : MonoBehaviour
{
    public GameObject playerPoop;
    public GameObject poop;
    public GameObject pickUp;
    public GameObject poopParticles;
    private bool notPickedUp;

    void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        notPickedUp = true;
        GameObject thePlayer = GameObject.Find("Character");
        PoopFlash poopScript = thePlayer.GetComponent<PoopFlash>();
        //poopScript.poopFlashBool = true;
        playerPoop = GameObject.FindGameObjectWithTag("PlayerPoop");
       // poopScript.poopFlashBool = false;
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
            if (Input.GetKeyDown("f"))
            {
                pickUp.SetActive(false);
                poopParticles.SetActive(true);
                Destroy(poop);
                
                notPickedUp = false;
                GameObject thePlayer = GameObject.Find("Character");
                PoopFlash poopScript = thePlayer.GetComponent<PoopFlash>();
                poopScript.poopFlashBool = true;
                playerPoop.SetActive(true);

            }
        }
    }
}
