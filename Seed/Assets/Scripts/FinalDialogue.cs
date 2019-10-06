using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class FinalDialogue : MonoBehaviour
{

    public TextMeshProUGUI textDisplay;
    public string[] sentences;

    private int index;

    public float typingSpeed;

    public GameObject continueButton;

    public GameObject poopObject;

    public GameObject fader;

    public AudioClip clip;
    public AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Type());
        source.clip = clip;
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
        continueButton.SetActive(false);
        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            poopObject.SetActive(true);
            source.PlayOneShot(source.clip);
            StartCoroutine(FadeOut());

        }
    }

    IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(3f);
        fader.SetActive(true);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Title");

        //New Scene coroutine
    }
    // Update is called once per frame
    void Update()
    {
        if(textDisplay.text == sentences[index])
        {
            continueButton.SetActive(true);
        } 
    }
}
