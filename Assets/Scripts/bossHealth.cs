using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class bossHealth : MonoBehaviour
{
    public float maxHealth;
    float currentHealth;
    public GameObject deathFX;
    
    bossController myBC;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        myBC = GetComponent<bossController>();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addDamage(float damage){
        myBC.isAggressive = true;
        if(damage<=0) return;
        currentHealth -= damage;
        if(currentHealth<=0) makeDead();
    }

    public void makeDead(){
        Instantiate(deathFX,transform.position, transform.rotation);
        myBC.enabled = false;
        myBC.makeDead();
        GetComponentInChildren<Renderer>().enabled = false;
        Invoke("EndScreen",1f);
        
    }

    public void EndScreen(){
        
        SceneManager.LoadScene("End Screen");
    }
}
