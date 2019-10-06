using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScroll : MonoBehaviour
{
    public GameObject player;
    private Animator anim; 

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x >= 7)
        {
            anim.SetTrigger("slideRight");
        }

        if (player.transform.position.x < 7)
        {
            anim.SetTrigger("slideLeft");
        }
    }
}
