using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollidePrevention : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D col)
    {
              
        Physics2D.IgnoreCollision(GameObject.FindGameObjectWithTag("Cow").GetComponent<BoxCollider2D>(), GetComponent<BoxCollider2D>());

        if (GameObject.FindGameObjectsWithTag("WateringCan").Length > 0)
        {
            Physics2D.IgnoreCollision(GameObject.FindGameObjectWithTag("WateringCan").GetComponent<BoxCollider2D>(), GetComponent<BoxCollider2D>());
        }
        
        if (GameObject.FindGameObjectsWithTag("PoopContainer").Length > 0)
        {
            Physics2D.IgnoreCollision(GameObject.FindGameObjectWithTag("PoopContainer").GetComponent<BoxCollider2D>(), GetComponent<BoxCollider2D>());
        }

        

    

    }

}
