using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoopFlash : MonoBehaviour
{
    public bool poopFlashBool;
    public GameObject poopPlayer;
    private bool doOnce;

    // Start is called before the first frame update
    void Start()
    {
        poopFlashBool = false;
        doOnce = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (poopFlashBool == true)
        {
            poopPlayer.SetActive(true);
        }

        if (doOnce == false)
        {
            if (poopFlashBool == false)
            {
                poopPlayer.SetActive(false);
                doOnce = true;
                
            }
        }
        
    }
}
