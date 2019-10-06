using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleController : MonoBehaviour
{

    public Animator anim;
    public GameObject fader;
    public ParticleSystem particles;
    public GameObject plantSound;
    public GameObject bGM;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        anim.SetTrigger("clickedSeed");
        bGM.SetActive(false);
        plantSound.SetActive(true);
        StartCoroutine(StartGames());
        StartCoroutine(SceneTransition());
        particles.Stop();
    }

    IEnumerator StartGames()
    {
        yield return new WaitForSeconds(2.5f);
        fader.SetActive(true);
    }

    IEnumerator SceneTransition()
    {
        yield return new WaitForSeconds(3.5f);
        SceneManager.LoadScene("MainScene");
    }
}
