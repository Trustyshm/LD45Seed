using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SunDialogue : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    public string[] deathsentences;
    private int index;
    private int deathindex;
    public float typingSpeed;

    private GameObject theSun;
    private GameObject thePlayer;

    public GameObject button;
    public GameObject dialogue;
    public GameObject buttonTwo;

    public Image sunPower;



    public Animator anim;

    private bool doOnce;

    public GameObject fader;

    public GameObject canvas;

    private bool buttonHider;



    // Start is called before the first frame update
    void Start()
    {
 
        StartCoroutine(Type());
        theSun = GameObject.Find("SunBossContainer");
        SunBeam sunBeam = theSun.GetComponent<SunBeam>();
        sunBeam.enabled =false;
        SunWander sunWander = theSun.GetComponent<SunWander>();
        sunWander.enabled = false;
        thePlayer = GameObject.Find("FlightCharacter");
        thePlayer.GetComponent<Rigidbody2D>().isKinematic = true;
        PlayerController playerController = thePlayer.GetComponent<PlayerController>();
        
        playerController.enabled = false;

        doOnce = false;

        buttonHider = false;

    }

    IEnumerator Type()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence()
    {
        button.SetActive(false);
        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            SunBeam sunBeam = theSun.GetComponent<SunBeam>();
            sunBeam.enabled = true;
            SunWander sunWander = theSun.GetComponent<SunWander>();
            sunWander.enabled = true;
            button.SetActive(false);
            dialogue.SetActive(false);
            PlayerController playerController = thePlayer.GetComponent<PlayerController>();
            thePlayer.GetComponent<Rigidbody2D>().isKinematic = false;
            playerController.enabled = true;
            buttonHider = true;

        }
    }

    public void DeathSentences()
    {
        buttonTwo.SetActive(false);
        if (deathindex < deathsentences.Length - 1)
        {
            deathindex++;
                textDisplay.text = "";
            StartCoroutine(TypeTwo());
        }
        else
        {
            //Fade Scene Out
            canvas.SetActive(false);
            fader.SetActive(true);
            //Open Return Scene
            StartCoroutine(NextScene());
            
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (doOnce == false)
        {
            if (sunPower.fillAmount >= 1f)
            {
                StartCoroutine(TypeTwo());
                textDisplay.text = "";
                dialogue.SetActive(true);
                buttonTwo.SetActive(true);
                doOnce = true;
                SunBeam sunBeam = theSun.GetComponent<SunBeam>();
                sunBeam.enabled = false;
                SunWander sunWander = theSun.GetComponent<SunWander>();
                sunWander.enabled = false;
            }
        }

        if (textDisplay.text == sentences[index] && buttonHider == false )
        {
            button.SetActive(true);
        }

        if (textDisplay.text == deathsentences[deathindex])
        {
            buttonTwo.SetActive(true);
        }


    }

    IEnumerator TypeTwo()
    {
        foreach (char letter in deathsentences[deathindex].ToCharArray())
        {
            
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    IEnumerator NextScene()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Return");
    }



}
