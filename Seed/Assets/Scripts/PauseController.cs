using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{

    public GameObject pauseMenu;
    private bool toggleBool;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            toggleBool = !toggleBool;
        }

        pauseMenu.SetActive(toggleBool);

        if (toggleBool)
        {
            Time.timeScale = 0;
        }

        if (!toggleBool)
        {
            Time.timeScale = 1;
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Title");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Resume()
    {
        toggleBool = !toggleBool;
    }
}
