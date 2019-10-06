using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTrigger : MonoBehaviour
{
    public GameObject playerCan;
    public GameObject water;
    public GameObject treeStageOne;

    private bool notWatered;
    private Animator anim;

    public GameObject rightWall;
    public GameObject wateringSound;
    public GameObject wateredSound;

    // Start is called before the first frame update
    void Start()
    {
        notWatered = true;
        anim = playerCan.GetComponent<Animator>();

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            if (playerCan.activeSelf == true)
            {
                if (notWatered == true)
                {
                    water.SetActive(true);
                }

            }




        }
    }


    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {

            water.SetActive(false);
        }
    }

    private void Update()
    {
        if (water.activeSelf)
        {
            if (Input.GetKeyDown("f"))
            {
                water.SetActive(false);
                notWatered = false;
                anim.SetTrigger("waterSeed");
                StartCoroutine(TreeGrow());
                StartCoroutine(TreeGrowItself());
                wateringSound.SetActive(true);


            }
        }
        IEnumerator TreeGrow()
        {
            yield return new WaitForSeconds(4.7f);
            playerCan.SetActive(false);
            treeStageOne.SetActive(true);
            
        }

        IEnumerator TreeGrowItself()
        {
            yield return new WaitForSeconds(2.7f);
            treeStageOne.SetActive(true);
            rightWall.SetActive(false);
            wateredSound.SetActive(true);

        }
    }

}
