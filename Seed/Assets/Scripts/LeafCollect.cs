using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeafCollect : MonoBehaviour
{
    public GameObject sunPowerObject;
    public Image sunPower;

    public AudioClip clip;
    public AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        sunPowerObject = GameObject.Find("HealthBar");
        sunPower = sunPowerObject.GetComponent<Image>();
        source.clip = clip;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            source.PlayOneShot(source.clip);
            StartCoroutine(DestroyLeaf());
            sunPower.fillAmount += 0.05f;
            

        }

       
    }

    IEnumerator DestroyLeaf()
    {
        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject);
    }

}
