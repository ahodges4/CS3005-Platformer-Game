using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slimeHealth : MonoBehaviour
{
    public float maxHealth;
    float currentHealth;
    public GameObject deathFX;

    slimeController mySC;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth=maxHealth;
        mySC = GetComponent<slimeController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addDamage(float damage){
        mySC.isAggressive = true;
        if(damage<=0) return;
        currentHealth -= damage;
        if(currentHealth<=0){
            makeDead();
        }
        
    }

    public void makeDead(){
        Instantiate(deathFX, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
