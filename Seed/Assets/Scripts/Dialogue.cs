using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;
    public GameObject playerCharacter;
    public GameObject leftWall;
    public bool alreadyEntered;
    public bool watered;
    private GameObject wateringCan;

    public bool sapling;
    private GameObject saplingGrew;

    public bool leafGrew;
    private GameObject oneLeaf;

    public bool darkScene;

    public Animator anim;

    private GameObject thePlayer;




  

    // Start is called before the first frame update
    void Start()
    {
        alreadyEntered = false;
        StartCoroutine(Type());
        watered = false;
        leafGrew = false;
        darkScene = false;
        thePlayer = GameObject.FindGameObjectWithTag("PlayerBody");
  
    }

    IEnumerator Type()
    {
        foreach(char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence()
    {
       
            if (index < sentences.Length - 1)
            {
                index++;
                textDisplay.text = "";
                StartCoroutine(Type());
            }
        
            
    }



    // Update is called once per frame
    void Update()
    {
    

       if (alreadyEntered == false)
        {
            if (playerCharacter.transform.position.x > -8.3)
            {
                StartCoroutine(EnterScene());
                leftWall.SetActive(true);
                alreadyEntered = true;
            }
        }

        wateringCan = GameObject.Find("WateringCanContainer");
        if (wateringCan !=null){
            StartWater();
        }

        saplingGrew = GameObject.Find("treestage1");
        if (saplingGrew != null)
        {
            StartFertilizer();
            
        }

        oneLeaf = GameObject.Find("OneLeaf");
        if (oneLeaf != null)
        {
            StartCelebrate();
        }

        if (thePlayer.transform.position.y > 5f)
        {
            Debug.Log("Scene Change");
            anim.SetTrigger("darkenFully");
            StartCoroutine(WaitForDarken());
        }


    }

    public void StartWater()
    {
        if (watered == false)
        {
            StartCoroutine(EnterScene());
            watered = true;
        }
    }

    public void StartFertilizer()
    {
        if (sapling == false)
        {
            NextSentence();
            sapling = true;
            
        }
    }

    public void StartCelebrate()
    {
        if (leafGrew == false)
        {
            NextSentence();
            leafGrew = true;
            StartCoroutine(Darkening());
        }
    }

    IEnumerator EnterScene()
    {
        yield return new WaitForSeconds(1f);
        NextSentence();
    }

    IEnumerator Darkening()
    {
        yield return new WaitForSeconds(4.2f);
        NextSentence();
        // Darken scene
        anim.SetTrigger("darkenScene");
        yield return new WaitForSeconds(4.0f);
        NextSentence();
        //Can fly!
        PlayerController playerController = thePlayer.GetComponent<PlayerController>();
        playerController.canFly = true;
    }

    IEnumerator WaitForDarken()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Space");
    }
}
