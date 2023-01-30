using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponPickup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            other.GetComponent<playerController>().AddFireRate(0.05f);//Increase Fire rate of player
            Destroy(gameObject);
        }
    }

    void OnTriggerStay2D(Collider2D other) {
        if(other.tag == "Player"){
            other.GetComponent<playerController>().AddFireRate(0.05f);
            Destroy(gameObject);
        }
    }
}
