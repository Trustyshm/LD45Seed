using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantActivator : MonoBehaviour
{
    public GameObject plantPrompt;
    public GameObject plantStars;
    public GameObject treeSoil;
    private Animator anim;
    private bool isPlanted;
    public GameObject wateringCan;
    public GameObject seedPlantedAudio;


    private void Start()
    {
        isPlanted = false;
        anim = anim = GetComponentInChildren<Animator>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (isPlanted == false)
            {
                plantPrompt.SetActive(true);
            }
            

        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            plantPrompt.SetActive(false);
        }
    }

    private void Update()
    {
        if (plantPrompt.activeSelf)
        {
            if (Input.GetKeyDown("f"))
            {
                isPlanted = true;
                anim.SetBool("isPlanted", isPlanted);
                plantStars.SetActive(true);
                seedPlantedAudio.SetActive(true);
                plantPrompt.SetActive(false);
                //StartCoroutine(TreeOne());
                treeSoil.SetActive(true);
                wateringCan.SetActive(true);
            } 
        }
    }

   /* IEnumerator TreeOne()
    {
        yield return new WaitForSeconds(2.3f);
        treeSoil.SetActive(true);
    } */
    

}
