using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadController : MonoBehaviour
{
    public GameObject deadMenu;
    private bool toggleBool;
    public GameObject thePauseController;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {



    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Title");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Space");

    }

    public void PlayerDied()
    {
        deadMenu.SetActive(true);
        thePauseController.SetActive(false);
    }
}
