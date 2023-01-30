using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletHit : MonoBehaviour
{

    public float weaponDamage;

    projectileController myPC;

    public GameObject drkFX;
    public GameObject slmFX;

    // Start is called before the first frame update
    void awake()
    {
        myPC = GetComponentInParent<projectileController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other){// If bullet hits enemy add damage
        if(other.tag == "Slime"){
                other.gameObject.GetComponent<slimeHealth>().addDamage(weaponDamage);
                Instantiate(slmFX,other.gameObject.transform.position,other.gameObject.transform.rotation);
                Destroy(gameObject);
            }
        else if(other.tag == "DarkKnight"){
            other.gameObject.GetComponent<darkKnightHealth>().addDamage(weaponDamage);
            Instantiate(drkFX,other.gameObject.transform.position,other.gameObject.transform.rotation);
            Destroy(gameObject);
        }
        else if(other.tag == "Boss"){
            other.gameObject.GetComponent<bossHealth>().addDamage(weaponDamage);
            Instantiate(drkFX,other.gameObject.transform.position,other.gameObject.transform.rotation);
            Destroy(gameObject);
        }
        else if(other.gameObject.layer == LayerMask.NameToLayer("Ground")) Destroy(gameObject);
    } 

    void OnTriggerStay2D(Collider2D other){
        
        if(other.tag == "Slime"){
                slimeHealth hurtEnemy = other.gameObject.GetComponent<slimeHealth>();
                hurtEnemy.addDamage(weaponDamage);
                Instantiate(slmFX,other.gameObject.transform.position,other.gameObject.transform.rotation);
                Destroy(gameObject);
        }
        else if(other.tag == "DarkKnight"){
            other.gameObject.GetComponent<darkKnightHealth>().addDamage(weaponDamage);
            Instantiate(drkFX,other.gameObject.transform.position,other.gameObject.transform.rotation);
            Destroy(gameObject);
        }
        else if(other.tag == "Boss"){
            other.gameObject.GetComponent<darkKnightHealth>().addDamage(weaponDamage);
            Instantiate(drkFX,other.gameObject.transform.position,other.gameObject.transform.rotation);
            Destroy(gameObject);
        }
        else if(other.gameObject.layer == LayerMask.NameToLayer("Ground")) Destroy(gameObject);
        
    }
}

