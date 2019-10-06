using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamController : MonoBehaviour
{
    public int speed;
    private Transform playerHere;

    private GameObject thePlayer;

    private float damageCooldownMax;
    private float damageCooldown;



    // Start is called before the first frame update
    void Start()
    {
        playerHere = GameObject.FindGameObjectWithTag("PlayerHere").transform;
        thePlayer = GameObject.FindGameObjectWithTag("PlayerBody");
        damageCooldownMax = 0.5f;
        damageCooldown = damageCooldownMax;
 ;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = playerHere.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle + 160f, Vector3.forward);

        transform.position = Vector2.MoveTowards(transform.position, playerHere.position, speed * Time.deltaTime);
        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(-transform.position), Time.deltaTime * 200);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 100 * Time.deltaTime);

        damageCooldown -= 1 * Time.deltaTime;
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            
            thePlayer = GameObject.Find("FlightCharacter");

            if (thePlayer != null)
            {
                Knockback knockback = thePlayer.GetComponent<Knockback>();
                
                Destroy(gameObject);
                if (damageCooldown <= 0){
                    knockback.TakeDamage();
                    damageCooldown = damageCooldownMax;
                }
                
            }
            


        }

    }


}
