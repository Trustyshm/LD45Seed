using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Knockback : MonoBehaviour
{
    public float thrust;
    private Rigidbody2D RB;
    public GameObject theSun;
    public float knockbackCooldown;
    private float currentCooldown;
    private PlayerController playerController;
    private GameObject sunBeam;
    public float maxHealth;
    private float currentHealth;
    private DeadController deadController;
    public GameObject deadControllerObject;

    private SoundRandomNoPlay soundRandomizer;


    public GameObject theSunThing;
   

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        currentCooldown = knockbackCooldown;
        playerController = GetComponent<PlayerController>();
        currentHealth = maxHealth;
        deadController = deadControllerObject.GetComponent<DeadController>();
        soundRandomizer = GetComponent<SoundRandomNoPlay>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (currentCooldown > 0)
        {
            currentCooldown -= 1 * Time.deltaTime;
            playerController.canMove = true;
        }

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            theSunThing.SetActive(false);
            soundRandomizer.PlayRandomClip();
            deadController.PlayerDied();
            
        }
    }

    public void TakeDamage()
    {
        currentHealth -= 2.5f;
        soundRandomizer.PlayRandomClip();

        

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (currentCooldown <= 0)
        {
            if (collision.gameObject.tag == "SunContainer")
            {

                
                TakeDamage();
                Vector3 moveDirection = (transform.position - theSun.transform.position).normalized;
                RB.AddForce(moveDirection.normalized * .2f);
                currentCooldown = knockbackCooldown;
                
                playerController.canMove = false;

            }
        }

        if (collision.gameObject.tag == "SunBeam")
        {
            
            sunBeam = GameObject.FindGameObjectWithTag("SunBeam");
            Destroy(sunBeam);
            TakeDamage();
        }
        
    }



    
}
