using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FertilizeTree : MonoBehaviour
{
    public GameObject playerPoop;
    public GameObject fertilize;
    public GameObject poopParticles;
    private bool notFertilized;
    private Animator anim;
    public GameObject oneLeaf;
    public GameObject fertilizeSound;
    public GameObject backgroundMusic;


    // Start is called before the first frame update
    void Start()
    {
        notFertilized = true;
        fertilize.SetActive(false);
        anim = GetComponentInParent<Animator>();
       
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (playerPoop.activeSelf)
            {
                if (notFertilized == true)
                {
                    fertilize.SetActive(true);
                }
            }



        }
    }


    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {

            fertilize.SetActive(false);
        }
    }

    private void Update()
    {
        if (fertilize.activeSelf)
        {
            if (Input.GetKeyDown("f"))
            {
                GameObject.Find("Character").GetComponent<PoopFlash>().enabled = false;
                fertilize.SetActive(false);
                poopParticles.SetActive(true);
                playerPoop.SetActive(false);
                notFertilized = false;
                anim.SetTrigger("growTwo");
                StartCoroutine(AddLeaf());
                backgroundMusic.SetActive(false);
                fertilizeSound.SetActive(true);


            }
        }
    }

    IEnumerator AddLeaf()
    {
        yield return new WaitForSeconds(0.7f);
        oneLeaf.SetActive(true);
    }
}
