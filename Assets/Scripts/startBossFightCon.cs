using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startBossFightCon : MonoBehaviour
{   
    bossController boss;
    // Start is called before the first frame update
    void Start()
    {
        boss = GameObject.FindGameObjectWithTag("Boss").GetComponent<bossController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit2D(Collider2D other) {//When player leaves spawn make boss aggressive
        if (other.tag == "Player"){
            boss.isAggressive = true;
        }
    }
}
