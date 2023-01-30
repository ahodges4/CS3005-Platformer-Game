using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class darkKnightHealth : MonoBehaviour
{
    public float maxHealth;
    float currentHealth;
    public GameObject deathFX;

    darkKnightController mydKC;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        mydKC = GetComponent<darkKnightController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addDamage(float damage){
        mydKC.isAggressive = true;
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
