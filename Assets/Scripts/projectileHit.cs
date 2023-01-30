using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileHit : MonoBehaviour
{
    public float damage;
    float count = 0;

    gravityProjectileController myPC;

    // Start is called before the first frame update
    void Awake()
    {
        myPC = GetComponent<gravityProjectileController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (count >= 3) damage = 0;
    }

    void OnTriggerEnter2D(Collider2D other){//If projectile hits player add damage
        if (other.tag == "Player"){
            if (myPC!=null) myPC.removeForce();
            Destroy(gameObject);
            other.gameObject.GetComponent<playerHealth>().addDamage(damage);
        }else if(other.gameObject.layer == LayerMask.NameToLayer("Ground")){
            count += 1;
        }
        
        

        
    }
}
