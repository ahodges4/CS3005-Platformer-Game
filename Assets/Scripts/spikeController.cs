using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikeController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {//Kill object when they touch spike
        Debug.Log(other.tag);
        if(other.tag == "Player" ){
            other.gameObject.GetComponent<playerHealth>().makeDead();
        }
        //else if(other.tag == "Slime"){
        //    other.gameObject.GetComponent<slimeHealth>().makeDead();
        //}
        else if(other.tag == "DarkKnight"){
            other.gameObject.GetComponent<darkKnightHealth>().makeDead();
        }
    }
}
