using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthPickup : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            other.GetComponent<playerHealth>().addHealth(5);
            Destroy(gameObject);
        }
    }
    private void OnTriggerStay2D(Collider2D other) {
        if(other.tag == "Player"){
            other.GetComponent<playerHealth>().addHealth(5);
            Destroy(gameObject);
        }
    }
}
