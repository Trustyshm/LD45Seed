using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator anim;
    private bool playerMoving;
    private Vector2 lastAction;
    private Rigidbody2D body;
    public float moveSpeed;
    private Vector2 movement;
    private bool doneMoving;
    public bool canFly;
    public bool canMove;
    private GameObject flyTrigger;


    private bool isRight;


    // Start is called before the first frame update
    void Start()
    {
        canMove = true;
        anim = GetComponentInChildren<Animator>();
        body = GetComponent<Rigidbody2D>();
        canFly = false;
        flyTrigger = GameObject.Find("FlyTrigger");
        if (flyTrigger != null)
        {
            canFly = true;
        }
    }

    // Update is called once per frame
    void Update()
    {

        movement.x = Input.GetAxisRaw("Horizontal"); 

        if (movement.x > 0)
        {
            doneMoving = false;
            playerMoving = true;
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }

        if (movement.x < 0)
        {
            doneMoving = false;
            playerMoving = true;
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }

        if (movement.x == 0)
        {
            playerMoving = false;
            doneMoving = true;
        }


        anim.SetBool("isMoving", playerMoving);

        if (canFly == true)
        {
            movement.y = Input.GetAxisRaw("Vertical");
        }
        

    }

    private void FixedUpdate()
    {
        if (canMove == true)
        {
            body.MovePosition(body.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
        

    }

}

