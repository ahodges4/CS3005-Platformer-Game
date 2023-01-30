using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDetectionClose : MonoBehaviour
{
    public bool nearby = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            nearby = true;
        } 
    }
    void OnTriggerExit2D(Collider2D other){
        if(other.tag == "Player"){
            nearby = false;
        } 
    }
}
