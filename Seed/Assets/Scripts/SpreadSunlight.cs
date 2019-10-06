using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpreadSunlight : MonoBehaviour
{

    public GameObject spreadSunlight;
    public GameObject sunlightParticles;
    public GameObject playerLeaf;
    private bool notSpread;
    //private Animator anim;
    public GameObject[] leaves;
    public int leafIndex;

    public GameObject dialogueController;

    public AudioClip clip;
    public AudioSource source;



    // Start is called before the first frame update
    void Start()
    {
        notSpread = true;
        spreadSunlight.SetActive(false);
        //anim = GetComponentInParent<Animator>();
        source.clip = clip;


    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

                if (notSpread == true)
                {
                    spreadSunlight.SetActive(true);
                }
            



        }
    }


    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {

            spreadSunlight.SetActive(false);
        }
    }

    private void Update()
    {
        if (spreadSunlight.activeSelf)
        {
            if (Input.GetKeyDown("f"))
            {
                GameObject.Find("Character").GetComponent<PoopFlash>().enabled = false;
                spreadSunlight.SetActive(false);
                sunlightParticles.SetActive(true);
                playerLeaf.SetActive(false);
                notSpread = false;
                //anim.SetTrigger("growTwo");
                StartCoroutine(ActivateLeaves());


            }
        }
    }

    IEnumerator ActivateLeaves()
    {
     
        foreach (GameObject leaf in leaves)
        {
            GameObject theLeaf = leaves[leafIndex];
            yield return new WaitForSeconds(0.05f);
            leafIndex++;
            leaf.SetActive(true);
            source.PlayOneShot(source.clip);
            StartCoroutine(ActivateDialogue());
        }
        
    }

    IEnumerator ActivateDialogue()
    {
        yield return new WaitForSeconds(3f);
        dialogueController.SetActive(true);

        
    }
}
