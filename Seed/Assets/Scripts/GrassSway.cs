using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassSway : MonoBehaviour
{

    private Animator anim;

    //public GameObject harvest;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            anim.SetTrigger("walkedOn");
           // harvest.SetActive(true);

        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            anim.SetTrigger("walkedOff");
           // harvest.SetActive(false);
        }
    }


}
