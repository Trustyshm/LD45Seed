using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassHarvest : MonoBehaviour
{
    public GameObject harvest;
    public GameObject grass;
    public GameObject grassParticles;
    public GameObject grassPlayer;
    private bool notHarvested;
    public GameObject grassHarvestSound;



    // Start is called before the first frame update
    void Start()
    {
        notHarvested = true;

    }



    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (notHarvested == true)
            {
                harvest.SetActive(true);
            }
            

        }
    }

    
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {

            harvest.SetActive(false);
        }
    }

    private void Update()
    {
        if (harvest.activeSelf)
        {
            if (notHarvested == true)
            {
                if (Input.GetKeyDown("f"))
                {
                    harvest.SetActive(false);
                    Destroy(grass);
                    grassParticles.SetActive(true);
                    grassPlayer.SetActive(true);
                    notHarvested = false;
                    grassHarvestSound.SetActive(true);



                }
            }
            
        }
    }
}
